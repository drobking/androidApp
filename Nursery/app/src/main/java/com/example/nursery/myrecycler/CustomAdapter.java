package com.example.nursery.myrecycler;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import java.util.List;
import com.example.nursery.R;

public class CustomAdapter extends RecyclerView.Adapter<CustomViewHolder> {

    private List<Model> modelList;
    private Context context;

    public CustomAdapter(List<Model> modelList, Context context) {
        this.modelList = modelList;
        this.context = context;
    }
    @NonNull
    @Override
    public CustomViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View layoutView = LayoutInflater
                .from(parent.getContext()).inflate(R.layout.row_item, parent, false);
        return new CustomViewHolder(layoutView);
    }

    @Override
    public void onBindViewHolder(@NonNull CustomViewHolder holder, int position) {
        if (modelList != null && position < modelList.size()) {
            Model model = modelList.get(position);
            holder.txt.setText(model.getName());
            holder.sub_txt.setText(model.getVersion());
            holder.img.setImageResource(R.drawable.logo);
        }
    }

    @Override
    public int getItemCount() {
        return modelList.size();
    }
}
