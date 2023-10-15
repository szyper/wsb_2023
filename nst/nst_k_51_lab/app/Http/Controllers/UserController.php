<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use Illuminate\Validation\Rule;

class UserController extends Controller
{
    public function account(Request $req){
      //return $req->input();
//      return $req->path();
//      return $req->url();
//      return $req->method();
//      return $req->input('email');

      $req->validate([
        'email' => 'required | email',
        'lastName' => 'required | min:5 | max:10'
      ],
      [
        'email.required' => 'Pole adres email jest wymagane',
        'lastName.required' => 'Pole nazwisko email jest wymagane',
        'lastName.min' => "Pole nazwisko musi mieć minimum :min znaków",
        'lastName.max' => "Pole nazwisko musi mieć minimum :max znaków",
      ]);

      return $req->input();
    }
}
