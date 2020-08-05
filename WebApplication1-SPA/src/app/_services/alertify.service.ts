import { Injectable } from '@angular/core';
import * as alertify from 'alertifyjs';

@Injectable({
  providedIn: 'root'
})
export class AlertifyService {   // this class literally is just using alertify to noticed clients if they have been successful etc.

constructor() { }

confirm(message: string, okCallback: () => any){   
  
  alertify.confirm(message, (e: any) => {
    if(e){
      okCallback();
    }  else{}
  });
}

success(message: string)
{
  alertify.success(message);
}

error(message: string)
{
  alertify.error(message);
}

warning(message: string)
{
  alertify.warning(message);
}

message(message: string)
{
  alertify.message(message);
}


}
