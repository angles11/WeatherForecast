import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class WeatherService {

constructor(private http: HttpClient) { }

  baseUrl = 'http://localhost:5000/api/weatherforecast/';

  getWeather(latitude: number, longitud: number): Observable<any> {
    return this.http.get<any>(this.baseUrl + latitude + '/' + longitud);
  }
}
