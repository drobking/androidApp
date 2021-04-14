package com.example.nursery;

import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.GridLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.os.Bundle;

import com.example.nursery.myrecycler.CustomAdapter;
import com.example.nursery.myrecycler.Model;

import java.util.ArrayList;
import java.util.List;

public class RecyclerActivity extends AppCompatActivity {

    private CustomAdapter customAdapter;
    private RecyclerView recyclerView;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_recycler);
        recyclerView = findViewById(R.id.rcv);
        recyclerView.setLayoutManager(new GridLayoutManager(this, 1,
                GridLayoutManager.VERTICAL, false));

        List<Model> list = new ArrayList<>();
        Model model = new Model("Славік","23");
        list.add(model);

        customAdapter=new CustomAdapter(list, this);
        recyclerView.setAdapter(customAdapter);

    }
}