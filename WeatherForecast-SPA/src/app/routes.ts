import { WeatherForecastComponent } from './weather-forecast/weather-forecast.component';
import { Routes } from '@angular/router';
import { NotFoundComponent } from './not-found/not-found.component';

export const appRoutes: Routes = [
    { path: '', component: WeatherForecastComponent },
    { path: '**', component: NotFoundComponent },
    {path: 'notfound', component: NotFoundComponent}
];

