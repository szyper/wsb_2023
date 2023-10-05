<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;

class PageController extends Controller
{
    public function show($drive){
      $drives = [
        'fdd' => 'dyskietka',
        'hdd' => 'dysk hdd',
        'ssd' => 'dysk ssd'
      ];

      return $drives[$drive]??'Błędne dane podane przez użytkownika';
    }
}
