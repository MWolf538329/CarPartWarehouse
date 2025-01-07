import { Component, createEffect, createSignal, For } from "solid-js";
import {
    Accordion,
    AccordionContent,
    AccordionItem,
    AccordionTrigger
} from "~/components/ui/accordion"

import ProductCard from './ProductCard';

const SubcategoryAccordion: Component<{ subcategory: Subcategory }> = props => {
    const [lowStock, setLowStock] = createSignal(false);
    createEffect(() => {
        let isLowStock = false;

        props.subcategory.products.forEach(product => {
            if (product.currentStock <= product.minStock) {
                isLowStock = true
            }
        })

        setLowStock(isLowStock)
    })

    return (
        <Accordion multiple={false} collapsible class={lowStock() ? "bg-red-300" : "bg-green-300"} >
            <AccordionItem value="item-1">
                <AccordionTrigger> {props.subcategory.name} - {props.subcategory.products.length} products </AccordionTrigger>
                <AccordionContent>
                    {/* Product Cards */}
                    <For each={props.subcategory.products}>
                        {product =>
                            <div>
                                <ProductCard product={product} />
                            </div>
                        }
                    </For>
                    {/* -------------------------------------------------------------------------------- */}
                </AccordionContent>
            </AccordionItem>
        </Accordion >
    )
}

export default SubcategoryAccordion