import { Observable } from "rxjs";
import { AreaService } from "../services/area.service";
import { Area } from "../models/area";
import { Component, OnInit } from "@angular/core";
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './area.component.html',
})
export class AreaComponent implements OnInit {
    areas: Area[];
    edited: boolean;
    add: boolean;
    area: Area;
    id: number;

    constructor(private areaService: AreaService,
        private router: Router) { }

    ngOnInit() {
        this.area = new Area();
        this.edited = true;
        this.add = true;
        this.reloadData();
    }

    reloadData() {
        this.areaService.getAreaList().subscribe(res => {
            this.areas = res.data;
        });
    }

    deleteArea(id: number) {
        var result = confirm("متاكد من حذف البيانات ؟");
        if (result) {
            this.areaService.deleteArea(id)
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

    setArea(id: number) {
        this.edited = false;
        this.add = true;
        this.id = id
        this.areaService.getArea(id)
            .subscribe(res => {
                this.area = res.data;
            });
    }

    addArea() {
        this.edited = true;
        this.add = false;
        this.area = new Area();
    }

    onAdd() {
        this.areaService.createArea(this.area)
            .subscribe(data => {
                this.reloadData();
                alert("تم حفظ البيانات");
                this.edited = true;
                this.add = true;
            }, error => console.log(error));
       
    }
    updateArea() {
        this.areaService.updateArea(this.id, this.area)
            .subscribe(data => {
                this.reloadData();
                alert("تم تعديل البيانات");
                this.edited = true;
                this.add = true;
            }, error => console.log(error));
        this.area = new Area();
    }

    onEdit() {
        this.updateArea();
    }

}
