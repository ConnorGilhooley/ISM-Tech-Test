// src/app/doors/doors.component.ts
import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { CommonModule } from '@angular/common';
import { DoorService, Door } from '../door.service';
import { DoorEditComponent } from '../door-edit/door-edit.component';


@Component({
  selector: 'app-doors',
  templateUrl: './doors.component.html',
  styleUrls: ['./doors.component.css'],
  standalone: true,
  imports: [CommonModule, MatDialogModule, MatCardModule, MatButtonModule, DoorEditComponent]
})
export class DoorsComponent implements OnInit {
  doors: Door[] = [];

  constructor(private doorService: DoorService, public dialog: MatDialog) {}

  ngOnInit(): void {
    this.loadDoors();
  }

  loadDoors(): void {
    this.doorService.getDoors().subscribe(doors => this.doors = doors);
  }

  openEditDialog(door: Door): void {
    const dialogRef = this.dialog.open(DoorEditComponent, {
      width: '250px',
      data: { ...door }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.doorService.updateDoor(result).subscribe(() => this.loadDoors());
      }
    });
  }
}
