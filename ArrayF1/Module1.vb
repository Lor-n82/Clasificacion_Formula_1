Module Module1

    Sub Main()

        Dim pilotos() As String = {"Vettel    ", "Alonso    ", "Raikkonen ", "Hamilton  ", "Button    ", "Webber    ", "Massa     "}
        Dim circuitos() As String = {"Australia", "Malasia", "China", "Bahrein", "Montmeló", "Mónaco", "Canada", "Silverstone"}
        Dim circuitosSiglas() As String = {"AU", "MA", "CH", "BA", "MO", "MÓ", "CA", "SI"}
        Dim clasificacion(7, 8) As Integer
        Dim opcion As Integer
        Dim sw As Boolean = False
        Dim resp As String
        Do
            Do
                Console.Write("FORMULA 1" & vbNewLine &
                              "" & vbNewLine &
                            "1. Introducir clasificación de la carrera" & vbNewLine &
                            "2. Mostrar información actual" & vbNewLine &
                            "3. Clasificación de pilotos" & vbNewLine &
                            "4. Salir " & vbNewLine &
                            "" & vbNewLine &
                            "Elije la opcion deseada: ")
                opcion = Console.ReadLine()

                'switch para el menu
                Select Case opcion
                    Case 1
                        clasificacion = clasificacionCarrera(elegirGranPremio(circuitos), clasificacion)
                    Case 2
                        mostrarInformacionActual(clasificacion, pilotos, circuitosSiglas)
                    Case 3
                        clasificacionPilotos(clasificacion, pilotos)
                    Case 4
                        Console.Write(vbNewLine & "Fin del programa")
                        System.Threading.Thread.Sleep(3000)
                        Exit Sub
                End Select
                If opcion < 1 Or opcion > 4 Then
                    Console.Write(vbNewLine & "Opcion incorrecta, introduce una opcion del 1 al 5")
                    System.Threading.Thread.Sleep(3000)
                    Console.Clear()
                End If
            Loop While opcion < 1 Or opcion > 4

            'Deseas continuar
            If opcion > 0 And opcion < 4 Then

                Console.Write(vbNewLine & "¿Deseas continuar?: ")
                resp = Console.ReadLine().ToLower

                If resp = "si" Then
                    sw = True
                ElseIf resp = "no" Then
                    sw = False
                    Console.Write(vbNewLine & "Fin del programa")
                    System.Threading.Thread.Sleep(3000)
                End If
                Console.Clear()
            End If

        Loop While sw = True

        System.Threading.Thread.Sleep(3000)

    End Sub

    Function elegirGranPremio(circuitos() As String) As Integer

        Dim opcion As Integer

        Console.Write(vbNewLine & "Selecciona el circuto: " & vbNewLine &
                          "" & vbNewLine &
            "1.Australia" & vbNewLine &
            "2.Malasia" & vbNewLine &
            "3.China" & vbNewLine &
            "4.Bahrein" & vbNewLine &
            "5.Montmeló" & vbNewLine &
            "6.Mónaco" & vbNewLine &
            "7.Canada" & vbNewLine &
            "8.Silverstone" & vbNewLine &
            "" & vbNewLine &
            ": ")
        opcion = Console.ReadLine() - 1

        Return opcion

    End Function

    Function clasificacionCarrera(numCircuito As Integer, clasificacion(,) As Integer) As Array

        Dim puestos As Integer
        Dim pilotos() As String = {"Vettel", "Alonso", "Raikkonen", "Hamilton", "Button", "Webber", "Massa"}

        Console.WriteLine("")

        For i = 0 To 6
            Console.Write("introduce la posicion de " & pilotos(i) & ": ")
            puestos = Console.ReadLine()
            clasificacion(i, numCircuito) = puestos

        Next

        Return clasificacion
    End Function

    Sub mostrarInformacionActual(clasificacion(,) As Integer, pilotos() As String, circuitos() As String)

        Console.WriteLine("")

        For i = 0 To 7
            Console.Write("             " & circuitos(i) & " ")

        Next

        Console.WriteLine("" & vbNewLine & "")
        For i = 0 To 6

            Console.Write(pilotos(i) & "  ")

            For j = 0 To 7

                Console.Write(" " & clasificacion(i, j) & "              ")
            Next
            Console.WriteLine("")
        Next

    End Sub

    Sub clasificacionPilotos(clasificacion(,) As Integer, pilotos() As String)

        Dim puntos, sumapuntos, puesto, i, x, cont As Integer
        Dim ordenarPun(6) As Integer
        Dim ordenar(6) As Integer
        Dim posiciones(6) As Integer
        Dim sw As Boolean

        For i = 0 To 6

            'Console.Write(vbNewLine & pilotos(i) & "  ")
            For j = 0 To 7

                puesto = clasificacion(i, j)

                Select Case puesto
                    Case 1
                        puntos = 12
                    Case 2
                        puntos = 10
                    Case 3
                        puntos = 8
                    Case 4
                        puntos = 6
                    Case 5
                        puntos = 4
                    Case 6
                        puntos = 2
                    Case 7
                        puntos = 1
                End Select

                sumapuntos = puntos + sumapuntos

                If j = 7 Then
                    ordenarPun(i) = sumapuntos
                End If
                'pongo a 0 los puntos
                puntos = 0
            Next
            'Console.Write(sumapuntos & " puntos" & vbNewLine)
            ' Reinicio el puesto y el acumulador
            sumapuntos = 0
            puesto = 0
        Next

        ordenar = ordenarPun.Clone
        Array.Sort(ordenar)
        Array.Reverse(ordenar)

        i = 0
        x = 0

        While x < pilotos.Length
            If ordenarPun(i) = ordenar(cont) Then
                posiciones(x) = i
                x = x + 1
                cont = cont + 1
                sw = True
            Else
                i = i + 1
                sw = False

            End If
            If sw = True Then
                i = 0
            End If
        End While


        For i = 0 To 6
            Console.WriteLine(vbNewLine & (i + 1) & "  " & pilotos(posiciones(i)) & "  " & ordenar(i) & " puntos")
        Next

    End Sub


End Module
