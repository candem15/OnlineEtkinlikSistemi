import { Component, OnInit } from '@angular/core';
import { UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { NgxSpinnerService } from 'ngx-spinner';
import { ListCategories } from 'src/app/contracts/list_categories';
import { ListCities } from 'src/app/contracts/list_cities';
import { ResponseInfo } from 'src/app/contracts/response_info';
import { CategoryService } from 'src/app/services/category.service';
import { CityService } from 'src/app/services/city.service';
import { CustomToastrService, ToastrMessageType, ToastrPosition } from 'src/app/services/custom-toastr.service';
import { EventService } from 'src/app/services/event.service';
import { BaseComponent } from '../base/base.component';

@Component({
  selector: 'app-create-event',
  templateUrl: './create-event.component.html',
  styleUrls: ['./create-event.component.scss']
})
export class CreateEventComponent extends BaseComponent implements OnInit {

  constructor(private formBuilder: UntypedFormBuilder,
    spinner: NgxSpinnerService,
    private categoryService: CategoryService,
    private cityService: CityService,
    private eventService: EventService,
    private toastrService: CustomToastrService) {
    super(spinner)
  }

  frmEvent: UntypedFormGroup;
  eventSubmitted: boolean = false;
  categories: ListCategories[] = null;
  cities: ListCities[] = null;

  async ngOnInit() {
    this.getCategories();
    this.getCities();
    this.frmEvent = this.formBuilder.group({
      eventName: ["",
        [
          Validators.required,
          Validators.minLength(3),
          Validators.maxLength(50),
        ]],
      address: ["",
        [
          Validators.required,
          Validators.minLength(10),
          Validators.maxLength(250),
        ]],
      applicationDeadline: [Date,
        [
          Validators.required
        ]],
      eventDate: [Date,
        [
          Validators.required
        ]],
      description: ["",
        [
          Validators.required
        ]],
      categoryId: ["",
        [
          Validators.required
        ]],
      cityId: ["",
        [
          Validators.required
        ]],
      maxParticipantsNumber: [Number,
        [
          Validators.required,
          Validators.min(2)
        ]],
      ticketPrice: [Number,
        [
          Validators.min(0)
        ]],
    })
  }

  async getCategories() {
    const allCategories: { categories: ListCategories[] } = await this.categoryService.read();

    this.categories = allCategories.categories;
  }
  async getCities() {
    const allCities: { cities: ListCities[] } = await this.cityService.read();

    this.cities = allCities.cities;
  }

  async onEventSubmit(event: Event) {
    this.eventSubmitted = true;
    if (this.frmEvent.invalid)
      return;
    const result: ResponseInfo = await this.eventService.create(event);
    if (result.succeeded) {
      this.toastrService.notification(result.message, "Başarılı!", ToastrMessageType.Success, ToastrPosition.TopRight)
    }
    else {
      this.toastrService.notification(result.message, "Hata!", ToastrMessageType.Error, ToastrPosition.TopRight)
    }
  }

  get componentEvent() {
    return this.frmEvent.controls;
  }

}
