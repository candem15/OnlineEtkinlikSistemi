import { Component, OnInit } from '@angular/core';
import { UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-user-event',
  templateUrl: './user-event.component.html',
  styleUrls: ['./user-event.component.scss']
})
export class UserEventComponent implements OnInit {

  constructor(private formBuilder: UntypedFormBuilder) { }
  frmEvent: UntypedFormGroup;
  ngOnInit(): void {
    this.frmEvent = this.formBuilder.group({
      name: ["",
        [
          Validators.required,
          Validators.minLength(3),
          Validators.maxLength(50),
        ]],
      address: ["",
        [
          Validators.minLength(10),
          Validators.maxLength(250),
        ]],
      applicationDeadline: ["",
        [
          Validators.minLength(4),
          Validators.maxLength(50),
        ]],
      eventDate: ["",
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
      maxParticipantsNumber: ["",
        [
          Validators.required,
          Validators.min(2)
        ]],
      ticketPrice: ["",
        [
          //Validators.required
        ]],
    })
  }

  async onEventSubmit(user: any) {

  }

  get componentEvent() {
    return this.frmEvent.controls;
  }

}
