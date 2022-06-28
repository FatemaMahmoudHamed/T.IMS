import { Injectable } from '@angular/core';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';


@Injectable({
  providedIn: 'root'
})
export class AlertService {

  constructor(private _snackBar: MatSnackBar) { }

  error(message:string):void{
    this._snackBar.open(message, ' ', {
      duration: 5000,
      horizontalPosition: 'end',
      verticalPosition: 'bottom',
      panelClass: ['bg-danger'],
    });
  }

  succuss(message:string):void{
    this._snackBar.open(message, ' ', {
      duration: 5000,
      horizontalPosition: 'end',
      verticalPosition: 'bottom',
      panelClass: ['bg-success'],
    });
  }

  info(message:string):void{
    this._snackBar.open(message, ' ', {
      duration: 5000,
      horizontalPosition: 'end',
      verticalPosition: 'bottom',
      panelClass: ['bg-info'],
    });
  }
}
