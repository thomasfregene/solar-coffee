<template>
    <div class="inventoryContainer">
        <h1 id="inventoryTitle">
            Inventory Dashboard
        </h1>
        <hr>

        <div>
            <solar-button @click.native="showNewProductModal" id="addnewBtn">
                Add New Item
            </solar-button>
            <solar-button @click.native="showShipmentmodal" id="receiveShipmentBtn">
                Receive Shipment
            </solar-button>
        </div>


        <table id="InventoryTable" class="table">
            <tr>
                <th>Item</th>
                <th>Quantity On-hand</th>
                <th>Unit Price</th>
                <th>Taxable</th>
                <th>Delete</th>
            </tr>

            <tr v-for="item in inventory" :key="item.id">
                <td>
                    {{item.product.name}}
                </td>
                <td>
                    {{item.quantityOnHand}}
                </td>
                <td>
                    {{item.product.price | price}}
                </td>
                <td>
                    <span v-if="item.product.isTaxable">
                        Yes
                    </span>
                    <span v-else>
                        No
                    </span>
                </td>
                <td>
                    <div>
                        X
                    </div>
                </td>
            </tr>
        </table>
        <new-product-modal
         v-if="isNewProductVisible"
         @close="closeModals"/>
        <shipment-modal 
        v-if="isShipmentVisible"
        :inventory="inventory" 
        @close="closeModals"/>
    </div>

</template>

<script lang="ts">
import {Component, Vue} from 'vue-property-decorator';
import{IProductInventory} from '@/types/Product';
import SolarButton from '@/components/SolarButton.vue';
@Component({
    name: 'Inventory',
    components: {}
})
export default class Inventory extends Vue{
    isNewProductVisible: boolean = false;
    isShipmentVisible: boolean = false;
    inventory: IProductInventory[] = [
        {
            id: 1,
            product:{
                id: 1,
                name: "Some Product",
                description: "Good Stuff",
                price: 100,
                createdOn: new Date(),
                updatedOn: new Date(),
                isTaxable: true,
                isArchived: false
            },
            quantityOnHand: 100,
            idealQuantity: 100
        },
          {
            id: 2,
            product:{
                id: 2,
                name: "Another Product",
                description: "Good Stuff",
                price: 100,
                createdOn: new Date(),
                updatedOn: new Date(),
                isTaxable: false,
                isArchived: false
            },
            quantityOnHand: 40,
            idealQuantity: 20
        }
    ];

    closeModal(){
        this.isShipmentVisible = false;
        this.isNewProductVisible = false;
    }

    showNewProductModal(){}

    showShipmentmodal(){}
}
</script>

<style lang="scss" scoped>

</style>