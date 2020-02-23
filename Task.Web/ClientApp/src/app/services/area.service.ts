import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Area } from '../models/area';

@Injectable({
    providedIn: 'root'
})
export class AreaService {

    private baseUrl = 'http://localhost:61097/api/area';

    constructor(private http: HttpClient) { }

    getArea(id: number): Observable<any> {
        return this.http.get(`${this.baseUrl}/${id}`);
    }

    createArea(area: Area): Observable<Object> {
        return this.http.post(`${this.baseUrl}`, area);
    }

    updateArea(id: number, value: any): Observable<Object> {
        return this.http.put(`${this.baseUrl}/${id}`, value);
    }

    deleteArea(id: number): Observable<any> {
        return this.http.delete(`${this.baseUrl}/${id}`, { responseType: 'text' });
    }

    getAreaList(): Observable<any> {
        return this.http.get(`${this.baseUrl}`);
    }
}
