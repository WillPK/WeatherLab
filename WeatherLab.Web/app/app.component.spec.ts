import { AppComponent } from './app.component';
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { HttpModule } from '@angular/http';

describe('Component: AppComponent', () => {
    let component: AppComponent;

    beforeEach(() => {
        TestBed.configureTestingModule({
            declarations: [AppComponent],
            imports: [HttpModule]
        }).compileComponents();

        component = TestBed.createComponent(AppComponent).componentInstance;
    });

    it('should create component', () => {
        expect(component).toBeDefined();
    });

    it('should set default value of London to City', () => {
        expect(component.city).toBe('London');
    });

    it('should set DisplayText properly when api result is empty', () => {
        var emptyResult = '{}';
        component.processResult(emptyResult);
        expect(component.displayText).toBe('Unknown city, please try again.');
    });

    it('should set DisplayText properly when api result is not empty', () => {
        var nonEmptyResult = '{"coord":{"lon":-0.13, "lat":51.51}}';
        component.processResult(nonEmptyResult);
        expect(component.displayText).toBe(nonEmptyResult);
    });
});
