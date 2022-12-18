package com.example.wsc2019_kazan_s1_27_04_2022_android.components

import android.app.DatePickerDialog
import androidx.compose.foundation.background
import androidx.compose.foundation.clickable
import androidx.compose.foundation.layout.Box
import androidx.compose.foundation.layout.Spacer
import androidx.compose.foundation.layout.fillMaxWidth
import androidx.compose.foundation.layout.padding
import androidx.compose.material.*
import androidx.compose.material.icons.Icons
import androidx.compose.material.icons.filled.DateRange
import androidx.compose.material.icons.filled.KeyboardArrowDown
import androidx.compose.runtime.Composable
import androidx.compose.runtime.getValue
import androidx.compose.runtime.mutableStateOf
import androidx.compose.runtime.saveable.rememberSaveable
import androidx.compose.runtime.setValue
import androidx.compose.ui.Modifier
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.platform.LocalContext
import androidx.compose.ui.unit.dp
import java.time.LocalDateTime
import java.time.format.DateTimeFormatter

@Composable
fun Spinner(
    spinnerItems: List<String>,
    selectedItem: String,
    onItemSelected: (String) -> Unit,
    modifier: Modifier = Modifier,
    isEnabled: Boolean = true
) {
    var enabled = spinnerItems.isNotEmpty() && isEnabled
    var tempItem = selectedItem
    if (selectedItem == "" && spinnerItems.isNotEmpty()){
        tempItem = spinnerItems[0]
        onItemSelected(tempItem)
    }

    if (!spinnerItems.contains(selectedItem) && spinnerItems.isNotEmpty()){
        tempItem = spinnerItems[0]
        onItemSelected(tempItem)
    }
    Box(modifier = modifier
        .fillMaxWidth()) {

        var expanded by rememberSaveable { mutableStateOf(false) }

        TextField(
            value = tempItem,
            onValueChange = {},
            trailingIcon = { Icon(Icons.Default.KeyboardArrowDown, contentDescription = null) },
            modifier = Modifier.fillMaxWidth(),
            singleLine = true,
            enabled = enabled
        )

        Spacer(modifier = Modifier
            .matchParentSize()
            .background(Color.Transparent)
            .clickable {
                if (enabled){
                    expanded = true
                }
            })

        DropdownMenu(
            expanded = expanded,
            onDismissRequest = { expanded = false },
        ) {
            spinnerItems.forEach {
                    item -> DropdownMenuItem(
                onClick = {
                    onItemSelected(item)
                    expanded = false
                },
            ) { Text(item) }
            }
        }
    }
}


@Composable
fun DateSelector(
    modifier: Modifier = Modifier,
    dateTime: LocalDateTime?,
    onDateSelected: (LocalDateTime?) -> Unit,
    labelText: String = "Select Date...",
)
{
    val context = LocalContext.current
    OutlinedButton(
        onClick = {
            val dpd = DatePickerDialog(
                context,
                null,
                dateTime?.year ?: 2022,
                dateTime?.monthValue?.minus(1) ?: 0,
                dateTime?.dayOfMonth ?: 1
            )
            dpd.setOnDateSetListener { _, year, month, day ->
                onDateSelected(LocalDateTime.of(year, month + 1, day, 0, 0))
            }

            dpd.setOnCancelListener {
                onDateSelected(null)
            }
            dpd.show()
        },
        modifier = modifier
    ) {
        Icon(Icons.Default.DateRange, contentDescription = null)
        Spacer(modifier = Modifier.padding(4.dp))
        if (dateTime != null){
            Text(text = dateTime.format(DateTimeFormatter.ofPattern("dd/MM/y")))
        }else   {
            Text(text = labelText)
        }
    }
}