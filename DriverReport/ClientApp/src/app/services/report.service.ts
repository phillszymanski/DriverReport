import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';

@Injectable()
export class ReportService {
  private drivers: Driver[] = [];
  private baseUrl: string;

  constructor(
    private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
    //http.get('assets/test_data.txt').subscribe(data => {
    //  http.post<Driver[]>(baseUrl + 'api/SampleData/WeatherForecasts', data).subscribe(result => {
    //    this.drivers = result;
    //  }, error => console.error(error));
    //})
    //http.get<Driver[]>(baseUrl + 'api/SampleData/WeatherForecasts').subscribe(result => {
    //  this.drivers = result;
    //}, error => console.error(error));
  }

  processFile(data) {
    return this.http.post<any>(this.baseUrl + 'api/Report/ProcessInputFile', { fileText: data }, { responseType: "json" }).toPromise().then(result => {
        //this.drivers = result;
        return result;
      }, error => console.error(error));
  }

}
