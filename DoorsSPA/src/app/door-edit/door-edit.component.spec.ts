import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DoorEditComponent } from './door-edit.component';

describe('DoorEditComponent', () => {
  let component: DoorEditComponent;
  let fixture: ComponentFixture<DoorEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DoorEditComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DoorEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
