import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Area } from '../models/area';
import { District } from '../models/District';

@Injectable({
    providedIn: 'root'
})
export class DistrictService {

    private baseUrl = 'http://localhost:61097/api/district';

    constructor(private http: HttpClient) { }

    getDistrict(id: number): Observable<any> {
        return this.http.get(`${this.baseUrl}/${id}`);
    }

    createDistrict(District: District): Observable<Object> {
        return this.http.post(`${this.baseUrl}`, District);
    }

    updateDistrict(id: number, value: any): Observable<Object> {
        return this.http.put(`${this.baseUrl}/${id}`, value);
    }

    deleteDistrict(id: number): Observable<any> {
        return this.http.delete(`${this.baseUrl}/${id}`, { responseType: 'text' });
    }

    getDistrictList(): Observable<any> {
        return this.http.get(`${this.baseUrl}`);
    }

    getDistrictView(): Observable<any> {
        return this.http.get(`${this.baseUrl}/GetAllView`);
    }
}
