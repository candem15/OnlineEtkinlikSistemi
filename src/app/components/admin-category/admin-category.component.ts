import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { NgxSpinnerService } from 'ngx-spinner';
import { CreateCategory } from 'src/app/contracts/create_category';
import { ListCategories } from 'src/app/contracts/list_categories';
import { UpdateCategory } from 'src/app/contracts/update_category';
import { CategoryService } from 'src/app/services/category.service';
import { CustomToastrService, ToastrMessageType, ToastrPosition } from 'src/app/services/custom-toastr.service';
import { BaseComponent, SpinnerType } from '../base/base.component';

@Component({
  selector: 'app-admin-category',
  templateUrl: './admin-category.component.html',
  styleUrls: ['./admin-category.component.scss']
})
export class AdminCategoryComponent extends BaseComponent implements OnInit {

  constructor(spinner: NgxSpinnerService, private categoryService: CategoryService, private toastrService: CustomToastrService) {
    super(spinner)
  }
  displayedColumns: string[] = ['CategoryName', 'UpdateCategory', 'DeleteCategory'];
  dataSource: MatTableDataSource<ListCategories> = null;
  categoryFormControl = new FormControl('', [Validators.required]);

  create(name: HTMLInputElement) {
    if (name.value == "") {
      this.toastrService.notification("Kategori ismini boş geçmeyiniz.",
        "Bilgilendirme!",
        ToastrMessageType.Warning,
        ToastrPosition.TopRight
      );
      return;
    }
    this.showSpinner(SpinnerType.SquareLoader);
    const createCategory: CreateCategory = new CreateCategory();
    createCategory.categoryName = name.value;

    this.categoryService.create(createCategory, () => {
      this.hideSpinner(SpinnerType.SquareLoader);
      this.toastrService.notification("Kategori eklendi.",
        "Başarılı!",
        ToastrMessageType.Success,
        ToastrPosition.TopRight
      );
    }, errorMessage => {
      this.toastrService.notification(errorMessage, "Hata!", ToastrMessageType.Error, ToastrPosition.TopRight);
    }
    );
  }

  async getAllCategories() {
    this.showSpinner(SpinnerType.SquareLoader);
    const allCategories: { categories: ListCategories[] } = await this.categoryService.read(
      () => this.hideSpinner(SpinnerType.SquareLoader),
      errorMessage => this.toastrService.notification(errorMessage, "Hata!", ToastrMessageType.Error, ToastrPosition.TopRight));

    this.dataSource = new MatTableDataSource<ListCategories>(allCategories.categories);
  }

  async deleteCategory(id: string) {
    this.showSpinner(SpinnerType.SquareLoader)
    this.categoryService.delete(id, async () => {
      this.toastrService.notification("Kategori silindi.", "Başarılı!", ToastrMessageType.Success, ToastrPosition.TopRight);
      await this.refreshCategories();
    }, errorMessage => {
      this.hideSpinner(SpinnerType.SquareLoader);
      this.toastrService.notification(errorMessage, "Hata!", ToastrMessageType.Error, ToastrPosition.TopRight);
    });
  }

  async updateCategory(id: string, newName: HTMLInputElement) {
    if (newName.value == "") {
      this.toastrService.notification("Kategori ismini boş geçmeyiniz.",
        "Bilgilendirme!",
        ToastrMessageType.Warning,
        ToastrPosition.TopRight
      );
      return;
    }
    this.showSpinner(SpinnerType.SquareLoader);
    const updateCategory: UpdateCategory = new UpdateCategory();
    updateCategory.categoryName = newName.value;
    updateCategory.id = id;
    this.categoryService.update(updateCategory, () => {
      this.hideSpinner(SpinnerType.SquareLoader);
      this.toastrService.notification("Kategori güncellendi.",
        "Başarılı!",
        ToastrMessageType.Success,
        ToastrPosition.TopRight
      );
      this.refreshCategories();
    }, errorMessage => {
      this.toastrService.notification(errorMessage, "Hata!", ToastrMessageType.Error, ToastrPosition.TopRight);
    }
    );
  }

  async refreshCategories() {
    await this.getAllCategories();
  }

  async ngOnInit() {
    await this.getAllCategories();
  }
}
