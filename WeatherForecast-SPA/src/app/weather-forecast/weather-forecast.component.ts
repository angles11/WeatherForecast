import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { CurrentWeather } from 'src/_models/current-weather';
import { Day } from 'src/_models/day';
import { WeatherService } from 'src/_services/weather.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-weather-forecast',
  templateUrl: './weather-forecast.component.html',
  styleUrls: ['./weather-forecast.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class WeatherForecastComponent implements OnInit {
  title = 'WeatherForecast-SPA';

  contentLoaded: Promise<boolean>;
  currentWeather: CurrentWeather;
  forecast: Day[];
  backgroundUrl: string;
  iconName: string;

  options = {
    types: ['(cities)']
  };


  constructor(private weatherService: WeatherService, private router: Router) {}
  ngOnInit() {
    if (window.navigator.geolocation) {
      window.navigator.geolocation.getCurrentPosition((position) => {
        this.getWeather(position.coords.latitude, position.coords.longitude);
      });
    }
  }

  public handleAddressChange(event: any) {

    const latitude = event.geometry.location.lat();
    const longitud = event.geometry.location.lng();

    this.getWeather(latitude, longitud);
  }

  getWeather(latitude: number, longitud: number) {
    this.weatherService.getWeather(latitude, longitud).subscribe(
      (response) => {
        this.currentWeather = response.currentWeather;
        this.forecast = response.days;
        this.getBackgroundAndIcon(this.currentWeather.id);
        this.getIconsForDays(this.forecast);
      },
      (error) => {
        this.router.navigate(['/notfound']);
      }, () => {
        this.contentLoaded = Promise.resolve(true);
      }
    );
  }

  getBackgroundAndIcon(id: number) {
    if (id >= 200 && id < 233) {
      this.backgroundUrl = 'https://images7.alphacoders.com/807/807537.jpg';
      this.iconName = 'thunder.svg';
    }
    else if (id >= 300 && id < 322) {
      this.backgroundUrl = 'https://images8.alphacoders.com/362/362049.jpg';
      this.iconName = 'rainy-3.svg';
    }
    else if (id >= 500 && id < 532) {
      this.backgroundUrl =
        'https://images4.alphacoders.com/709/thumb-1920-709010.jpg';
      this.iconName = 'rainy-6.svg';
    }
    else if (id >= 600 && id < 623) {
      this.backgroundUrl =
        'https://images.wallpaperscraft.com/image/snow_winter_trees_136654_2560x1080.jpg';
      this.iconName = 'snowy-3.svg';
    }
    else if (id === 701) {
      this.backgroundUrl = 'https://www.wallpaperbetter.com/wallpaper/566/282/350/boat-rowboat-lake-fog-mist-hd-2K-wallpaper-middle-size.jpg';
      this.iconName = 'cloudy.svg';
    }

    else if (id === 800) {
      this.backgroundUrl =
        'https://cdn.wallpaperhub.app/cloudcache/f/b/b/d/a/d/fbbdada7ce61a2181a4de8da8b40f2f106ffbf6b.jpg';
      this.iconName = 'day.svg';
    }
    else if (id >= 801 && id < 803) {
      this.backgroundUrl = 'https://img.wallpapersafari.com/desktop/1600/900/22/20/fZaOMz.jpg';
      this.iconName = 'cloudy-day-1.svg';
    }

    else if (id >= 803 && id < 805) {
      this.backgroundUrl = 'https://images.alphacoders.com/777/77763.jpg';
      this.iconName = 'cloudy.svg';
    }
  }

  getIconsForDays(days: Day[]) {
    for (let i = 0; i < days.length; i++) {

      const day = days[i];

      const date = new Date();
      date.setDate(date.getDate() + i);
      day.date = date;

      if (day.id >= 200 && day.id  < 233) {
      day.iconName  = 'thunder.svg';
    }
      else if (day.id  >= 300 && day.id  < 322) {
      day.iconName = 'rainy-3.svg';
    }
      else if (day.id  >= 500 && day.id  < 532) {
      day.iconName = 'rainy-6.svg';
    }
      else if (day.id  >= 600 && day.id  < 623) {
      day.iconName = 'snowy-3.svg';
    }
      else if (day.id  === 800) {
      day.iconName = 'day.svg';
    }
      else if (day.id  >= 801 && day.id  < 805) {
      day.iconName = 'cloudy.svg';
    }
    }
  }
}
