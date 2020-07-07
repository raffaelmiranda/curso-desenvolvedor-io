import { PipeTransform, Pipe } from '@angular/core';

@Pipe({
    name: 'imageformater'
})
export class ImageFormaterPipe implements PipeTransform {
    transform(imagem: string, caminho: string = '', substituir: boolean) {
        if (caminho == 'default')
            caminho = 'assets';

        if (imagem.length == 0 && substituir) {
            imagem = 'semCapa.jpg'
        }

        return "/" + caminho + "/" + imagem
    }

}