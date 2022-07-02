import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ContentmainComponent } from './contentmain.component';

describe('ContentmainComponent', () => {
  let component: ContentmainComponent;
  let fixture: ComponentFixture<ContentmainComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ContentmainComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ContentmainComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
