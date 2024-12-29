import { Component, createEffect, createSignal } from "solid-js";
import {
    Card,
    CardContent,
    // CardDescription,
    // CardFooter,
    // CardHeader,
    // CardTitle
  } from "~/components/ui/card"
  
  interface Product{
    id: number;
    name: string;
    brand: string;
    currentStock: number;
    minStock: number;
    maxStock: number;
  }

const ProductCard:Component<{product:Product}> = props => {
    let [backgroundColor, setBackgroundColor] = createSignal("#888888");
    createEffect(() => {
        if(props.product.currentStock > props.product.minStock){
            setBackgroundColor("#c8e6c9");
        }
        else if (props.product.currentStock <= props.product.minStock){
            setBackgroundColor("#ff8a80")
        }
    })

    return (
    <Card style={{"background-color": backgroundColor()}}>
        <CardContent>
          <p>Name: {props.product.name} - Brand: {props.product.brand} - CurrentStock: {props.product.currentStock} - MinStock: {props.product.minStock} - MaxStock: {props.product.maxStock}</p>
        </CardContent>
    </Card>
    )
}

export default ProductCard