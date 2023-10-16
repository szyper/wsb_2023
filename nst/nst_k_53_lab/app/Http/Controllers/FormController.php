<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;

class FormController extends Controller
{
    public function showUser(Request $req){
      switch ($req->input('gender')){
        case 'm':
          $gender = 'mężczyzna';
          break;
        case 'w':
          $gender = 'kobieta';
          break;
      }
      $user = [
        'firstName' => $req->input('firstName'),
        'email' => $req->input('email'),
        'pass' => $req->input('pass'),
        'gender' => $gender
      ];
      return view('forms.showFormUser', $user);
    }
}
