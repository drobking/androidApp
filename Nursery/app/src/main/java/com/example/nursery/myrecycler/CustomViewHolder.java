package com.example.nursery.myrecycler;

import android.view.View;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;
import com.example.nursery.R;

public class CustomViewHolder extends RecyclerView.ViewHolder {

    private View view;
    public ImageView img;
    public TextView txt;
    public TextView sub_txt;

    public CustomViewHolder(@NonNull View itemView) {
        super(itemView);
        this.view = itemView;
        img=itemView.findViewById(R.id.img);
        txt = itemView.findViewById(R.id.txt);
        sub_txt = itemView.findViewById(R.id.sub_txt);
    }

    public View getView() {
        return view;
    }
}
