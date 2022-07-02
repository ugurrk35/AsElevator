import { isNgTemplate } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Category } from '../models/category';
import { CategoryService } from '../services/category.service';

@Component({
  selector: 'app-categorylist',
  templateUrl: './categorylist.component.html',
  styleUrls: ['./categorylist.component.css']
})
export class CategorylistComponent implements OnInit {
  category: Category[]=[];
  categoryId : number| null | undefined ;

  title = 'aselevator';
  constructor(
    private categoryService: CategoryService,
    private toastrService: ToastrService

  ) {}
  ngOnInit(): void {
   this.getAllCategory();
  }
  getAllCategory() {
    this.categoryService.getAllCategory().subscribe((response)=>{
      if ((this.category = response.data)) {
        this.toastrService.success(response.message, 'Başarılı');
      } else {
        this.toastrService.error(response.message,'Hata!');
      }
    });


    console.log(this.getAllCategory );
  }
  onDelete(id:number)
  {
this.categoryService.deleteCategory(id).subscribe(res=>{
  this.category=this.category.filter(item=>item.id !==id);
  console.log('Post deleted successfully!');
})
  }




}


