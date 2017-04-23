import { Http, Response, Headers, RequestOptions } from '@angular/http'
import { Component } from '@angular/core';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import { Observable } from 'rxjs/Observable';

@Component({
    selector: 'my-app',
    templateUrl: 'app/app.html'
})
export class AppComponent {

    city: string = 'London';
    displayText: string;
    loading: boolean = false;
    parent: AppComponent = this;
    constructor(private http: Http) {

    }

    search() {
        this.loading = true;
        // in a real world app, this is extracted out in a separate injectable service
        this.post("api/weather?city=" + this.city, {})
            .subscribe(result => this.processResult(result));
    }

    processResult(result: string) {
        this.displayText = this.isEmpty(result)
            ? 'Unknown city, please try again.'
            : result;

        this.loading = false;
    }

    isEmpty(val: string) {
        return Object.keys(val).length === 0;
    }

    private post(url: string, data: any): Observable<any> {

        var headers = new Headers({ 'Content-Type': 'application/json' });
        var options = new RequestOptions({ headers: headers });

        var post = this.http.post(url, data, options);

        return post.map(this.extractData).catch(this.handleError);
    }

    private extractData(res: Response) {
        if (res.status === 204) {
            return {};
        }

        return res.json() || {};
    }

    private handleError(error: any) {
        console.log('handling error...');
        // In a real world app, we might use a remote logging infrastructure
        // We'd also dig deeper into the error to get a better message
        let errMsg = (error.message) ? error.message : error.status ? `${error.status} - ${error.statusText}` : 'Server error';
        console.error(errMsg); // log to console instead
        return Observable.throw(errMsg);
    }

}
