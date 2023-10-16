<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;

class UserController extends Controller
{
    public function show(Request $req){
      $req->validate([
        'firstName' => 'required | min:4 | max:10',
        'email' => 'required | email',
        'pass' => 'required',
        'pass_confirmation' => 'required | same:pass',
      ],
      [
        'firstName.required' => 'Pole :attribute jest wymagane',
        'firstName.min' => 'Pole :attribute musi zawierać minimum :min znaki',
        'firstName.max' => 'Pole :attribute musi zawierać maksymalnie :max znaków',

        'email.required' => 'Pole :attribute jest wymagane',
        'email.email' => 'Pole :attribute musi być adresem email',

        'pass.required' => 'Pole :attribute jest wymagane',
        'pass_confirmation.required' => 'Pole :attribute jest wymagane',
        'pass_confirmation.same' => 'Pole :attribute musi być identyczne co pole :other',

      ]);
//      return $req->input();
//      return $req->input('email');
//      return $req->path();
//      return $req->method();
//      return $req->url();
      return $req->input();

    }
}
