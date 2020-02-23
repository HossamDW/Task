import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Area } from '../models/area';
import { City } from '../models/city';

@Injectable({
    providedIn: 'root'
})
export class CityService {

    private baseUrl = 'http://localhost:61097/api/city';

    constructor(private http: HttpClient) { }

    getCity(id: number): Observable<any> {
        return this.http.get(`${this.baseUrl}/${id}`);
    }

    createCity(city: City): Observable<Object> {
        return this.http.post(`${this.baseUrl}`, city);
    }

    updateCity(id: number, value: any): Observable<Object> {
        return this.http.put(`${this.baseUrl}/${id}`, value);
    }

    deleteCity(id: number): Observable<any> {
        return this.http.delete(`${this.baseUrl}/${id}`, { responseType: 'text' });
    }

    getCityList(): Observable<any> {
        return this.http.get(`${this.baseUrl}`);
    }

    getCityView(): Observable<any> {
        return this.http.get(`${this.baseUrl}/GetAllView`);
    }

    getCityViewByArea(id: number): Observable<any> {
        return this.http.get(`${this.baseUrl}/GetAllViewByArea?id=${id}`);
    }
}
