<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;

class FormController extends Controller
{
    public function form(Request $req){
      $req->validate(
        [
          'firstName' => 'required | min:3 | max: 10',
          'email' => 'required | min:3 | max: 10 | email',
          'pass' => 'required | min:8'
        ],
        [
          'firstName.required' => 'Wypełnij pole imię',
          'firstName.min' => 'Minimalna długość imienia: :min',
          'firstName.max' => 'Maksymalna długość imienia: :max',
          'email.required' => 'Wypełnij pole email',
          'pass.required' => 'Wypełnij pole hasło',
          'pass.min' => 'Minimalna długość hasła: :min',
        ]
      );
      switch ($req->input('gender')){
        case 'm':
          $gender = "mężczyzna";
          break;
        case 'k':
          $gender = "kobieta";
          break;
      }
      $user = [
        'firstName' => $req->input('firstName'),
        'email' => $req->input('email'),
        'pass' => $req->input('pass'),
        'gender' => $gender,
      ];
      return view('form', $user);
    }
}
