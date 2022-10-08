import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { NgxSpinnerService } from 'ngx-spinner';
import { CreateCity } from 'src/app/contracts/create_city';
import { ListCities } from 'src/app/contracts/list_cities';
import { UpdateCity } from 'src/app/contracts/update_city';
import { CityService } from 'src/app/services/city.service';
import { CustomToastrService, ToastrMessageType, ToastrPosition } from 'src/app/services/custom-toastr.service';
import { BaseComponent, SpinnerType } from '../base/base.component';

@Component({
  selector: 'app-admin-city',
  templateUrl: './admin-city.component.html',
  styleUrls: ['./admin-city.component.scss']
})
export class AdminCityComponent extends BaseComponent implements OnInit {

  constructor(spinner: NgxSpinnerService, private cityService: CityService, private toastrService: CustomToastrService) {
    super(spinner)
  }

  displayedColumns: string[] = ['CityName', 'UpdateCity', 'DeleteCity'];
  dataSource: MatTableDataSource<ListCities> = null;
  cityFormControl = new FormControl('', [Validators.required, Validators.minLength(1)]);

  create(name: HTMLInputElement) {
    if (name.value == "") {
      this.toastrService.notification("Şehir ismini boş geçmeyiniz.",
        "Bilgilendirme!",
        ToastrMessageType.Warning,
        ToastrPosition.TopRight
      );
      return;
    }
    this.showSpinner(SpinnerType.SquareLoader);
    const createCity: CreateCity = new CreateCity();
    createCity.cityName = name.value;

    this.cityService.create(createCity, () => {
      this.hideSpinner(SpinnerType.SquareLoader);
      this.toastrService.notification("Şehir eklendi.",
        "Başarılı!",
        ToastrMessageType.Success,
        ToastrPosition.TopRight
      );
      this.refreshCities();
    }, errorMessage => {
      this.toastrService.notification(errorMessage, "Hata!", ToastrMessageType.Error, ToastrPosition.TopRight);
    }
    );
  }

  async getAllCities() {
    this.showSpinner(SpinnerType.SquareLoader);
    const allCities: { cities: ListCities[] } = await this.cityService.read(
      () => this.hideSpinner(SpinnerType.SquareLoader),
      errorMessage => this.toastrService.notification(errorMessage, "Hata!", ToastrMessageType.Error, ToastrPosition.TopRight));

    this.dataSource = new MatTableDataSource<ListCities>(allCities.cities);
  }

  async deleteCity(id: string) {
    this.showSpinner(SpinnerType.SquareLoader)
    this.cityService.delete(id, async () => {
      this.toastrService.notification("Şehir silindi.", "Başarılı!", ToastrMessageType.Success, ToastrPosition.TopRight);
      await this.refreshCities();
    }, errorMessage => {
      this.hideSpinner(SpinnerType.SquareLoader);
      this.toastrService.notification(errorMessage, "Hata!", ToastrMessageType.Error, ToastrPosition.TopRight);
    });
  }

  async updateCity(id: string, newName: HTMLInputElement) {
    if (newName.value == "") {
      this.toastrService.notification("Şehir ismini boş geçmeyiniz.",
        "Bilgilendirme!",
        ToastrMessageType.Warning,
        ToastrPosition.TopRight
      );
      return;
    }
    this.showSpinner(SpinnerType.SquareLoader);
    const updateCity: UpdateCity = new UpdateCity();
    updateCity.cityName = newName.value;
    updateCity.id = id;
    this.cityService.update(updateCity, () => {
      this.hideSpinner(SpinnerType.SquareLoader);
      this.toastrService.notification("Şehir güncellendi.",
        "Başarılı!",
        ToastrMessageType.Success,
        ToastrPosition.TopRight
      );
      this.refreshCities();
    }, errorMessage => {
      this.toastrService.notification(errorMessage, "Hata!", ToastrMessageType.Error, ToastrPosition.TopRight);
    }
    );
  }

  async refreshCities() {
    await this.getAllCities();
  }

  async ngOnInit() {
    await this.getAllCities();
  }

}
