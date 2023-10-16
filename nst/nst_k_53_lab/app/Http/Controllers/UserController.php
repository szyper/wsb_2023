<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;

class UserController extends Controller
{
    public function show(Request $req){
      $req->validate([
        'firstName' => 'required | min:3 |max:5',
        'email' => 'required | email | min:8 |max:20',
        'pass' => 'required | min:6 | max:10',
        'pass_confirmation' => 'required | min:6 | max:10 | same:pass',
      ],
      [
        'firstName.required' => 'Wypełnij pole :attribute',
        'firstName.min' => 'Pole :attribute musi mieć minimum :min znaki',
        'firstName.max' => 'Pole :attribute musi mieć maksimum :max znaki',

        'email.required' => 'Wypełnij pole :attribute',
        'email.min' => 'Pole :attribute musi mieć minimum :min znaków',
        'email.max' => 'Pole :attribute musi mieć maksimum :max znaków',

        'pass.required' => 'Wypełnij pole :attribute',
        'pass.min' => 'Pole :attribute musi mieć minimum :min znaków',
        'pass.max' => 'Pole :attribute musi mieć maksimum :max znaków',

        'pass_confirmation.required' => 'Wypełnij pole :attribute',
        'pass_confirmation.min' => 'Pole :attribute musi mieć minimum :min znaków',
        'pass_confirmation.max' => 'Pole :attribute musi mieć maksimum :max znaków',
        'pass_confirmation.same' => 'Pole :attribute musi być taki sam jak pole :other'
      ]);

      //return $req->input();
//      return $req->input('email');
//      return $req->url();
//      return $req->method();
      return $req->path();
    }
}
