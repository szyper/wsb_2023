<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Models\Article;

class ArticleController extends Controller
{
    public function index(){
        $articles = Article::all();

        //print_r($articles);

        return view('articles.index', ['articles' => $articles]);
    }
}
