import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RowcolumnComponent } from './rowcolumn.component';

describe('RowcolumnComponent', () => {
  let component: RowcolumnComponent;
  let fixture: ComponentFixture<RowcolumnComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RowcolumnComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RowcolumnComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
