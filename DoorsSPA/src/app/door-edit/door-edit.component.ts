// src/app/door-edit/door-edit.component.ts
import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA, MatDialogModule } from '@angular/material/dialog';
import { Door } from '../door.service';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-door-edit',
  templateUrl: './door-edit.component.html',
  styleUrls: ['./door-edit.component.css'],
  standalone: true,
  imports: [MatDialogModule, MatFormFieldModule, MatSelectModule, MatButtonModule, CommonModule] // Add necessary modules
})
export class DoorEditComponent {
  constructor(
    public dialogRef: MatDialogRef<DoorEditComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Door) { }

  onNoClick(): void {
    this.dialogRef.close();
  }
}
