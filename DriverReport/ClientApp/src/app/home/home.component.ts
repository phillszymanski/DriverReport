import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ReportService } from '../services/report.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public drivers: any[];
  
  constructor(private reportService: ReportService, private http: HttpClient) {
    var self = this;
    fetch('assets/test_data.txt')
      .then(response => response.text())
      .then(response => {
        this.reportService.processFile(response).then(drivers => {
          self.drivers = drivers;
        });
      })
    //this.http.get('assets/test_data.txt', { responseType: 'text' }).subscribe(data => {
    //  this.reportService.processFile(data);
    //})
  }


}
