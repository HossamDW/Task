import { Observable } from "rxjs";
import { Component, OnInit } from "@angular/core";
import { Router } from '@angular/router';
import { CityView } from "../models/city-view";
import { City } from "../models/city";
import { CityService } from "../services/city.service";
import { AreaService } from "../services/area.service";
import { Area } from "../models/area";

@Component({
    selector: 'app-home',
    templateUrl: './city.component.html',
})
export class CityComponent implements OnInit {
    cities: CityView[];
    edited: boolean;
    add: boolean;
    city: City;
    id: number;
    areas: Area[];

    constructor(private cityService: CityService, private areaService: AreaService,
        private router: Router) { }

    ngOnInit() {
        this.city = new City();
        this.edited = true;
        this.add = true;
        this.reloadData();
        this.areaService.getAreaList().subscribe(res => {
            this.areas = res.data;
        });
    }

    reloadData() {
        this.cityService.getCityView().subscribe(res => {
            this.cities = res.data;
        });
    }

    deleteCity(id: number) {
        var result = confirm("متاكد من حذف البيانات ؟");
        if (result) {
            this.cityService.deleteCity(id)
                .subscribe(
                    data => {
                        this.reloadData();
                        alert("تم تعديل البيانات");
                        this.edited = true;
                        this.add = true;
                    },
                    error => console.log(error));
        }

    }

    setCity(id: number) {
        this.edited = false;
        this.add = true;
        this.id = id
        this.cityService.getCity(id)
            .subscribe(res => {
                this.city = res.data;
                console.log(this.city);

            });
    }

    addCity() {
        this.edited = true;
        this.add = false;
        this.city = new City();
    }

    onAdd() {
        this.city.areaId = parseInt(this.city.areaId.toString());
        this.cityService.createCity(this.city)
            .subscribe(data => {
                this.reloadData();
                alert("تم حفظ البيانات");
                this.edited = true;
                this.add = true;
            }, error => console.log(error));

    }
    updateCity() {
        this.city.areaId = parseInt(this.city.areaId.toString());
        this.cityService.updateCity(this.id, this.city)
            .subscribe(data => {
                this.reloadData();
                alert("تم تعديل البيانات");
                this.edited = true;
                this.add = true;
            }, error => console.log(error));
        this.city = new City();
    }

    onEdit() {
        this.updateCity();
    }

}
