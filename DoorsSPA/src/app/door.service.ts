// src/app/door.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { tap } from 'rxjs/operators';
import { LocalStorageService } from './local-storage.service';

export interface Door {
  id: number;
  name: string;
  isOpen: string;
  isLocked: string;
  isAlarmed: string;
}

@Injectable({
  providedIn: 'root'
})
export class DoorService {
  private apiUrl = 'https://localhost:7093/api/doors';

  constructor(private http: HttpClient, private localStorageService: LocalStorageService) { }

  getDoors(): Observable<Door[]> {
    const storedDoors = this.localStorageService.getItem('doors');
    if (storedDoors) {
      return of(JSON.parse(storedDoors));
    } else {
      return this.http.get<Door[]>(this.apiUrl).pipe(
        tap(doors => this.localStorageService.setItem('doors', JSON.stringify(doors)))
      );
    }
  }

  updateDoor(door: Door): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${door.id}`, door).pipe(
      tap(() => {
        const storedDoors = JSON.parse(this.localStorageService.getItem('doors') || '[]');
        const index = storedDoors.findIndex((d: Door) => d.id === door.id);
        if (index !== -1) {
          storedDoors[index] = door;
          this.localStorageService.setItem('doors', JSON.stringify(storedDoors));
        }
      })
    );
  }
}
