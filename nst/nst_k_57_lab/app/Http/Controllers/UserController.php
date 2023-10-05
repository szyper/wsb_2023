<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;

class UserController extends Controller
{
    public function show(Request $req){
      $req->validate([
        'firstName' => 'required | min:3 | max:10',
        'email' => 'required | email',
      ]);
//      return $req->input();
//      return $req->input('email');
//      return $req->path();
//      return $req->method();
//      return $req->url();
      return $req->input();

    }
}
