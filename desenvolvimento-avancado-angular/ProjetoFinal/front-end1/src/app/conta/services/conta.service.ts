import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Usuario } from "../models/usuario";

@Injectable()
export class ContaService {
    constructor(private http: HttpClient) { }

    registrarUsuario(usuario: Usuario): void {

    }

    login(usuario: Usuario): void {

    }
}
