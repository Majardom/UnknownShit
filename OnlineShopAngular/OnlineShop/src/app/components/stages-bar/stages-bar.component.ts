import { Component, OnInit, Input } from '@angular/core';
import { Stage } from 'src/app/models/orders/stage';
import { OrdersService } from 'src/app/services/orders/orders.service';

@Component({
  selector: 'app-stages-bar',
  templateUrl: './stages-bar.component.html',
  styleUrls: ['./stages-bar.component.css']
})
export class StagesBarComponent implements OnInit {

  stages: Stage[];
  @Input()
  activeStage: Stage;

  constructor(private orderService: OrdersService) { }

  ngOnInit() {
    this.setStages();
  }

  log(a){
    console.log(a);
  }

  setStages(){
    this.orderService.getAllStages().subscribe(founded => this.stages = founded);
  }

  getWidthPercents() : number{
    return Math.round(100/this.stages.length) - 2;
  }

  getStyle(stage:Stage) : string{
    return (stage.Id == this.activeStage.Id || stage.Id < this.activeStage.Id)?
    'active' : '';
  }

}
