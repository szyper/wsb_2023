<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;

class FormController extends Controller
{
    public function showForm(Request $req){
      //return $req->input();
      //return $req->input('firstName');
      //return $req->path();
      //return $req->url();

      $req->validate([
        'firstName' => 'required | min:3 | max:10',
        'lastName' => 'required | min:2',
        'email' => 'required | email',
        'color' => 'required'
      ]);

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
      }
      echo <<< DATA
      Imię i nazwisko: {$req->input('firstName')} {$req->input('lastName')}<br>
      Email: {$req->input('email')}<br>
      Ulubiony kolor: $color<br>
DATA;
    }
}
