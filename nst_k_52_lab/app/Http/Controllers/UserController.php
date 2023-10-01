<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;

class UserController extends Controller
{
    public function showUser(Request $req){
//      return 'Dane z form-a';
      //return $req->input();
//      return $req->input('lastName');
//      return $req->path();
//      return $req->url();
//      return $req->method();

      $req->validate(
        [
          'firstName' => 'required | min:3 | max:10',
          'lastName' => 'required | min:2',
          'email' => 'email',
          'color' => 'required'
        ]
      );

      //return $req->input();
      switch ($req->input('color')){
        case 'r':
          $color = 'czerwony';
          break;
        case 'g':
          $color = 'zielony';
          break;
        case 'b':
          $color = 'niebieski';
          break;
        default:
          $color = 'błędne dane podane przez użytkownika!';
      }
      $data = <<< DATA
        Imię i nazwisko: {$req->input('firstName')} {$req->input('lastName')}<br>
        Email: {$req->input('email')}<br>
        Ulubiony kolor: $color
DATA;
      return $data;

    }
}
