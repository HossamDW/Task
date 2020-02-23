"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var AreaService = /** @class */ (function () {
    function AreaService(http) {
        this.http = http;
        this.baseUrl = core_1.Inject('BASE_URL') + '/api/area';
    }
    AreaService.prototype.getArea = function (id) {
        return this.http.get(this.baseUrl + "/GetBy/" + id);
    };
    AreaService.prototype.createArea = function (area) {
        return this.http.post("" + this.baseUrl, area);
    };
    AreaService.prototype.updateArea = function (id, value) {
        return this.http.put(this.baseUrl + "/" + id, value);
    };
    AreaService.prototype.deleteArea = function (id) {
        return this.http.delete(this.baseUrl + "/" + id, { responseType: 'text' });
    };
    AreaService.prototype.getAreaList = function () {
        return this.http.get("" + this.baseUrl);
    };
    return AreaService;
}());
exports.AreaService = AreaService;
//# sourceMappingURL=area.service.js.map