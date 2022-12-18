package com.example.wsc2019_kazan_s1_27_04_2022_android

import android.os.Bundle
import android.util.Log
import androidx.activity.ComponentActivity
import androidx.activity.compose.setContent
import androidx.activity.result.contract.ActivityResultContracts
import androidx.lifecycle.viewmodel.compose.viewModel
import androidx.navigation.NavType
import androidx.navigation.compose.NavHost
import androidx.navigation.compose.composable
import androidx.navigation.compose.rememberNavController
import androidx.navigation.navArgument
import com.example.wsc2019_kazan_s1_27_04_2022_android.screens.AssetCatalogue
import com.example.wsc2019_kazan_s1_27_04_2022_android.screens.AssetTransfer
import com.example.wsc2019_kazan_s1_27_04_2022_android.screens.RegisteringAssets
import com.example.wsc2019_kazan_s1_27_04_2022_android.screens.TransferHistory
import com.example.wsc2019_kazan_s1_27_04_2022_android.ui.theme.WSC2019Kazan_S1_27042022AndroidTheme


class MainActivity : ComponentActivity() {

    val requestPermissionLauncher = registerForActivityResult(
        ActivityResultContracts.RequestPermission()
    ) { isGranted ->
        if (isGranted) {
            Log.i("kilo", "Permission granted")
        } else {
            Log.i("kilo", "Permission denied")
        }
    }

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)

        setContent {
            WSC2019Kazan_S1_27042022AndroidTheme {
                val appViewModel: AppViewModel = viewModel()

                val navHostController = rememberNavController()
                navHostController.addOnDestinationChangedListener {
                    _, _, _ -> appViewModel.refreshData()
                }

                NavHost(
                    navController = navHostController,
                    startDestination = "home"
                ){

                    composable("home") {

                        AssetCatalogue(appViewModel, navController = navHostController,
                            drawable = R.drawable.ic_launcher_background)
                    }

                    composable(
                        "assetTransfers/{id}",
                        arguments = listOf(
                            navArgument("id") {
                                type = NavType.IntType
                            }
                        )
                    )
                    {

                        AssetTransfer(navHostController, it.arguments?.getInt("id")!!, appViewModel)
                    }

                    composable(
                        "register?id={id}",
                        arguments = listOf(
                            navArgument("id") {
                                type = NavType.IntType
                                defaultValue = -1
                            }
                        )
                    ){
                        RegisteringAssets(appViewModel, navHostController, it.arguments?.getInt("id")!!)
                    }

                    composable(
                        "transferHistory/{id}",
                        arguments = listOf(
                            navArgument("id") {
                                type = NavType.IntType
                            }
                        )
                    ){
                        TransferHistory(appViewModel, it.arguments?.getInt("id")!!, navHostController)
                    }

                }

            }
        }
    }
}


