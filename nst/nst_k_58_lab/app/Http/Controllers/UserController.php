<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;

class UserController extends Controller
{
    public function showUser(Request $req){
      $req->validate([
        'firstName' => 'required | min:3 | max:10',
        'lastName' => 'required | min:2',
        'email' => 'required | email'
      ]);
      //return $req->input();
      //return $req->path();
      //return $req->method();
      //return $req->input();
      echo <<< DATA
      Imię i nazwisko: {$req->input('firstName')} {$req->input('lastName')}<br>
      Email: {$req->input('email')}
DATA;

    }
}
