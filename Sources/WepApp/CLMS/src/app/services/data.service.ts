import { Injectable } from '@angular/core';

@Injectable()
export class DataService {

    public getCourses() {
        return ['CLIW', 'DOTNET', 'AI', 'SI'];
    }

}
