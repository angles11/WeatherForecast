import { Component, OnInit } from '@angular/core';
import { WeatherService } from 'src/_services/weather.service';
import { CurrentWeather } from 'src/_models/current-weather';
import { Day } from 'src/_models/day';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'WeatherForecast-SPA';

  constructor() {}
  ngOnInit() {
  }

}
