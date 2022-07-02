import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CategorylistComponent } from './categorylist/categorylist.component';
import { ContentmainComponent } from './contentmain/contentmain.component';

const routes: Routes = [
  {path : "", pathMatch : "full", component : ContentmainComponent},
  {path : "categorylist",component: CategorylistComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
