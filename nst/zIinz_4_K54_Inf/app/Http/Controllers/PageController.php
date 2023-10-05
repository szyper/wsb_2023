<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;

class PageController extends Controller
{
    public function show($drive){
      //return 'Kontroler o nazwie PageController';
      /*
      $drives = [
        'fdd' => 'dyskietka',
        'hdd' => 'dysk hdd',
        'ssd' => 'dysk ssd'
      ];
      return $drives[$drive]??'Błędne dane podane przez użytkownika';
      */

      $drives = match($drive){
        'fdd' => 'dyskietka',
        'hdd' => 'dysk hdd',
        'ssd' => 'dysk ssd',
        default => 'Błędne dane podane przez użytkownika'
      };
      return $drives;
    }
}
