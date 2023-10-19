<?php

namespace App\Http\Controllers;

use Couchbase\View;
use Illuminate\Http\Request;

class UserFormController extends Controller
{
    public function showForm(Request $req){
      $req->validate([
        'firstName' => 'required | min:3 | max:15',
        'lastName' => 'required',
        'email' => 'required | min:5 | max:50 | email',
      ]);
//      return View('showuser', $req->input());
      return View('showuser', $req);
    }
}

