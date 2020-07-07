import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'filesize'
})
export class FileSizePipe implements PipeTransform {


    transform(size: number) {
        let tamanhoCalculo = (size / (1024 * 1024))
        let extension = 'MB'

        if (tamanhoCalculo > 1024) {
            tamanhoCalculo = (tamanhoCalculo / 1024);
            extension = 'GB'
        }

        return tamanhoCalculo.toFixed(2) + extension;
    }

}