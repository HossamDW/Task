import { Observable } from "rxjs";
import { Component, OnInit } from "@angular/core";
import { Router } from '@angular/router';
import { AreaService } from "../services/area.service";
import { Area } from "../models/area";
import { District } from "../models/district";
import { DistrictView } from "../models/district-view";
import { DistrictService } from "../services/district.service";
import { CityService } from "../services/city.service";
import { parse } from "querystring";

@Component({
    selector: 'app-home',
    templateUrl: './district.component.html',
})
export class DistrictComponent implements OnInit {
    cities: District[];
    edited: boolean;
    add: boolean;
    district: District;
    id: number;
    areas: Area[];
    districts: DistrictView[];

    constructor(private districtService: DistrictService, private cityService: CityService, private areaService: AreaService,
        private router: Router) { }

    ngOnInit() {
        this.district = new District();
        this.edited = true;
        this.add = true;
        this.reloadData();
        this.areaService.getAreaList().subscribe(res => {
            this.areas = res.data;
        });
    }

    reloadData() {
        this.districtService.getDistrictView().subscribe(res => {
            this.districts = res.data;
        });
    }

    onAreaChange(newValue) {
        console.log(newValue);
        this.cityService.getCityViewByArea(parseInt(newValue)).subscribe(res => {
            this.cities = res.data;
        });
    }

    deleteDistrict(id: number) {
        var result = confirm("متاكد من حذف البيانات ؟");
        if (result) {
            this.districtService.deleteDistrict(id)
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

    setDistrict(id: number) {
        this.edited = false;
        this.add = true;
        this.id = id
        this.districtService.getDistrict(id)
            .subscribe(res => {
                this.district = res.data;
                this.cityService.getCityViewByArea(this.district.areaId).subscribe(res => {
                    this.cities = res.data;
                });
            });
    }

    addDistrict() {
        this.edited = true;
        this.add = false;
        this.district = new District();
    }

    onAdd() {
        this.district.areaId = parseInt(this.district.areaId.toString());
        this.district.cityId = parseInt(this.district.cityId.toString());
        this.districtService.createDistrict(this.district)
            .subscribe(data => {
                this.reloadData();
                alert("تم حفظ البيانات");
                this.edited = true;
                this.add = true;
            }, error => console.log(error));

    }
    updateDistrict() {
        this.district.areaId = parseInt(this.district.areaId.toString());
        this.district.cityId = parseInt(this.district.cityId.toString());

        this.districtService.updateDistrict(this.id, this.district)
            .subscribe(data => {
                this.reloadData();
                alert("تم تعديل البيانات");
                this.edited = true;
                this.add = true;
            }, error => console.log(error));
        this.district = new District();
    }

    onEdit() {
        this.updateDistrict();
    }

}
