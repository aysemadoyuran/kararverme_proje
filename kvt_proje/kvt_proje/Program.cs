using System;

namespace odev
{
    class Program
    {
        static void Main(string[] args)
        {
         
            bool cikis = false;

            while (cikis!=true)
            {
                Console.WriteLine("Belirsizlik Altında Karar Verme Problemi Çözümü Programı");
                Console.WriteLine("HOŞGELDİNİZ! Maliyet Yapılı Problem mi Getiri Yapılı Problem mi Çözmek İstiyorsunuz?");
                Console.WriteLine("(Maliyet Yapılı ise 1 Getiri Yapılı İse 0 ı Seçiniz.)");
                int secim = Convert.ToInt32(Console.ReadLine());
                string devammi;
                //Maliyet 
                if (secim == 1)
                {
                    Console.Clear();
                    Console.WriteLine("MALİYET YAPILI BELİRSİZLİK ALTINDA KARAR VERME PROBLEM ÇÖZÜMÜ");
                    Console.WriteLine(" ");
                    Console.WriteLine("Kaç Alternatif Olsun?");
                    int alternatif=0;
                    alternatif = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Kaç Doğal Durum Olsun?");
                    int bagımsız_deger = 0;
                    bagımsız_deger = Convert.ToInt32(Console.ReadLine());

                    string[] alternatifler = new string[alternatif];
                    for (int i = 0; i < alternatif; i++)
                    {
                        Console.WriteLine("{0}. Alternatifi Giriniz ", i + 1);
                        alternatifler[i] = Console.ReadLine();
                    }


                    string[] degerler = new string[bagımsız_deger];
                    for (int i = 0; i < bagımsız_deger; i++)
                    {
                        Console.WriteLine("{0}. Bağımsız Değeri Giriniz", i + 1);
                        degerler[i] = Console.ReadLine();
                    }

                    int[,] sayilar = new int[alternatif, bagımsız_deger];
                    for (int i = 0; i < alternatif; i++)
                    {
                        for (int j = 0; j < bagımsız_deger; j++)
                        {
                            Console.WriteLine("{0} Alternatifin {1} Değeri:", alternatifler[i], degerler[j]);
                            sayilar[i, j] = Convert.ToInt32(Console.ReadLine());
                        }

                    }


                    int[] maxdegerler = new int[alternatif];
                    int[] mindegerler = new int[alternatif];


                    int min = sayilar[0, 0];
                    for (int i = 0; i < alternatif; i++)
                    {
                        for (int j = 0; j < bagımsız_deger; j++)
                        {
                            if (min > sayilar[i, j])
                            {
                                min = sayilar[i, j];

                            }
                        }
                        mindegerler[i] = min;
                        min = sayilar[0, 0];
                    }


                    int enb = 0;
                    for (int i = 0; i < alternatif; i++)
                    {
                        for (int j = 0; j < bagımsız_deger; j++)
                        {
                            if (enb < sayilar[i, j])
                            {
                                enb = sayilar[i, j];

                            }
                        }
                        maxdegerler[i] = enb;
                        enb = 0;
                    }


                    int iyimserlik;
                    int kotumserlik;
                    iyimserlik = sayilar[0, 0];
                    int mindepo = 0;
                    int enb_depo = 0;
                    for (int i = 0; i < alternatif; i++)
                    {
                        if (iyimserlik > mindegerler[i]) 
                        {
                            mindepo = i;
                            iyimserlik = mindegerler[i];

                        }
                    }

                    kotumserlik = maxdegerler[0];
                    for (int i = 0; i < alternatif; i++)
                    {
                        if (kotumserlik>maxdegerler[i])
                        {
                            enb_depo = i;
                            kotumserlik = maxdegerler[i];
                        }
                        enb_depo = 0;
                    }


                    Console.Clear();
                    Console.WriteLine("İyimserlik Değeri:{0}", iyimserlik);
                    Console.WriteLine("Karar:{0}", alternatifler[mindepo]);
                    Console.WriteLine("Kötümserlik Değeri:{0}", kotumserlik);
                    Console.WriteLine("Karar:{0}", alternatifler[enb_depo]);




                    //Hurwics
                    Console.WriteLine("Alpha Değerini Girin:");
                    double alpha = Convert.ToDouble(Console.ReadLine());
                    double kotu = 1 - alpha;
                    int minsayac = 0;
                    int maxsayac = 0;

                    int[] harwıcs = new int[alternatif];
                    for (int i = 0; i < alternatif; i++)
                    {
                        harwıcs[i] = Convert.ToInt32((alpha * mindegerler[minsayac]) + (kotu * maxdegerler[maxsayac]));
                        minsayac++;
                        maxsayac++;
                    }


                    int enb_harwics = harwıcs[0];
                    int harwics_depo = 0;
                    for (int i = 0; i < alternatif; i++)
                    {
                        Console.WriteLine("{0} Harwics Değeri:", alternatifler[i]);
                        Console.WriteLine(harwıcs[i]);
                        if (enb_harwics > harwıcs[i])
                        {
                            enb_harwics = harwıcs[i];
                            harwics_depo = i;
                        }
                    }

                    Console.WriteLine("Karar:{0},{1}", enb_harwics, alternatifler[harwics_depo]);
                    Console.WriteLine("----------------------------------------");
                    
                    
                    int es_olasılık = bagımsız_deger;
                    double[] esolasilik = new double[alternatif];
                    Console.WriteLine("Laplace Kriterine Göre Hesaplamalar:");
                    double top = 0;

                    //Eş Olasılık
                    for (int i = 0; i < alternatif; i++)
                    {
                        for (int j = 0; j < bagımsız_deger; j++)
                        {
                           
                            top = top + (sayilar[i, j] / es_olasılık);
                            esolasilik[i] = top;
                        }
                        top = 0;
                    }


                    double enb_laplace = sayilar[0,0];
                    int laplacedepo = 0;
                    for (int i = 0; i < alternatif; i++)
                    {
                        Console.WriteLine("{0} Alternatifinin Laplace Değeri{1} ", alternatifler[i], esolasilik[i]);
                        if (enb_laplace > esolasilik[i])
                        {
                            enb_laplace = esolasilik[i];
                            laplacedepo = i;
                        }
                    }


                    Console.WriteLine("Karar:{0},{1}", enb_laplace, alternatifler[laplacedepo]);
                    Console.WriteLine("----------------------------------------");

                    Console.WriteLine("Hesaplama İşlemleriniz Sona Ermiştir. Tekrardan hesap yapmak ister misiniz? (Evetse E Hayırsa Herhangi bir tuşa basınız.)).");
                    devammi = Console.ReadLine();
                    if (devammi == "E" || devammi == "e")
                    {
                        Console.Clear();
                        cikis = false;

                    }
                    else
                    {
                        cikis = true;
                        Console.Clear();
                        Console.WriteLine("Başarıyla Çıkış Yapıldı");
                    }  
                    


                }


                //Getiri Hesaplamaları
                else if (secim == 0)
                {

                    Console.Clear();
                    Console.WriteLine("GETİRİ YAPILI BELİRSİZLİK ALTINDA KARAR VERME PROBLEM ÇÖZÜMÜ");
                    Console.WriteLine(" ");


                    int iyimserlik = 0;
                    int kotumserlik = 0;
                    int alternatif = 0;
                    int mindepo = 0;
                    int bagımsız_deger = 0;
                    int enb = 0;
                    int enb_depo = 0;


                    Console.WriteLine("Kaç Alternatif Olsun?");
                    alternatif = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Kaç Doğal Durum Olsun?");
                    bagımsız_deger = Convert.ToInt32(Console.ReadLine());


                    string[] alternatifler = new string[alternatif];
                    for (int i = 0; i < alternatif; i++)
                    {
                        Console.WriteLine("{0}. Alternatifi Giriniz", i + 1);
                        alternatifler[i] = Console.ReadLine();
                    }





                    string[] degerler = new string[bagımsız_deger];
                    for (int i = 0; i < bagımsız_deger; i++)
                    {
                        Console.WriteLine("{0}. Bağımsız Değeri Giriniz", i + 1);
                        degerler[i] = Console.ReadLine();
                    }

                    

                    int[,] sayilar = new int[alternatif, bagımsız_deger];
                    for (int i = 0; i < alternatif; i++)
                    {
                        for (int j = 0; j < bagımsız_deger; j++)
                        {
                            Console.WriteLine("{0} Alternatifin {1} Değeri:", alternatifler[i], degerler[j]);
                            sayilar[i, j] = Convert.ToInt32(Console.ReadLine());
                        }

                    }


                    int[] mindegerler = new int[alternatif];
                    int[] maxdegerler = new int[alternatif];


                    int min = sayilar[0, 0];
                    for (int i = 0; i < alternatif; i++)
                    {
                        for (int j = 0; j < bagımsız_deger; j++)
                        {
                            if (min > sayilar[i, j])
                            {
                                min = sayilar[i, j];

                            }
                        }
                        mindegerler[i] = min;
                        min = sayilar[0, 0];
                    }


                    
                    for (int i = 0; i < alternatif; i++)
                    {
                        for (int j = 0; j < bagımsız_deger; j++)
                        {
                            if (enb < sayilar[i, j])
                            {
                                enb = sayilar[i, j];
                                enb_depo = i;

                            }
                        }
                        maxdegerler[i] = enb;
                        enb = 0;
                    }

 

                    for (int i = 0; i < alternatif; i++)
                    {
                        if (kotumserlik < mindegerler[i])
                        {
                            mindepo = i;
                            kotumserlik = mindegerler[i];

                        }
                    }


                    for (int i = 0; i < alternatif; i++)
                    {
                        if (iyimserlik < maxdegerler[i])
                        {
                            enb_depo = i;
                            iyimserlik = maxdegerler[i];

                        }
                    }

                    
                    Console.Clear();
                    Console.WriteLine("İyimserlik Değeri:{0}", iyimserlik);
                    Console.WriteLine("Karar:{0}", alternatifler[enb_depo]);
                    Console.WriteLine("Kötümserlik Değeri:{0}", kotumserlik);
                    Console.WriteLine("Karar:{0}", alternatifler[mindepo]);


                    //Hurwics Hesaplamaları 
                    Console.WriteLine("Alpha Değerini Girin:");
                    double alpha = Convert.ToDouble(Console.ReadLine());
                    double kotu = 1 - alpha;
                    int minsayac = 0;
                    int maxsayac = 0;


                    int[] harwıcs = new int[alternatif];
                    for (int i = 0; i < alternatif; i++)
                    {
                        harwıcs[i] = Convert.ToInt32((alpha * maxdegerler[maxsayac]) + (kotu * mindegerler[minsayac]));
                        minsayac++;
                        maxsayac++;
                    }

                    int enb_harwics = 0;
                    int harwics_depo = 0;
                    for (int i = 0; i < alternatif; i++)
                    {
                        Console.WriteLine("{0} Harwics Değeri:", alternatifler[i]);
                        Console.WriteLine(harwıcs[i]);
                        if (enb_harwics < harwıcs[i])
                        {
                            enb_harwics = harwıcs[i];
                            harwics_depo = i;
                        }
                    }


                    Console.WriteLine("Karar:{0},{1}", enb_harwics, alternatifler[harwics_depo]);



                    double top = 0;
                    int es_olasılık = bagımsız_deger;
                    double[] laplace = new double[alternatif];


                    //Eş Olasılık
                    Console.WriteLine("Laplace Kriterine Göre Hesaplamalar:");
                    for (int i = 0; i < alternatif; i++)
                    {
                        for (int j = 0; j < bagımsız_deger; j++)
                        {
                            top = Convert.ToDouble(top + (sayilar[i, j] / es_olasılık));
                            laplace[i] = top;
                        }
                        top = 0;
                    }
                 

                    double enb_laplace = 0;
                    int laplacedepo = 0;
                    for (int i = 0; i < alternatif; i++)
                    {
                        Console.WriteLine("{0} Alternatifinin Laplace Değeri{1} ", alternatifler[i], laplace[i]);
                        if (enb_laplace < laplace[i])
                        {
                            enb_laplace = laplace[i];
                            laplacedepo = i;
                        }
                    }



                    Console.WriteLine("Karar:{0},{1}", enb_laplace, alternatifler[laplacedepo]);
                    Console.WriteLine("----------------------------------------");


                    Console.WriteLine("Hesaplama İşlemleriniz Sona Ermiştir. Tekrardan hesap yapmak ister misiniz? (Evetse E Hayırsa Herhangi bir tuşa basınız.)).");
                    devammi = Console.ReadLine();
                    if (devammi == "E" || devammi == "e")
                    {
                        Console.Clear();
                        cikis = false;
                    }
                    else
                    {
                        cikis = true;
                        Console.Clear();
                        Console.WriteLine("Başarıyla Çıkış Yapıldı");
                    }
                }


                //Hatalı Karakter Girişi 
                else
                {
                    Console.WriteLine("Hatalı karakter girişi yaptınız tekrardan giriş yapmak ister misiniz? (Evetse E Hayırsa Herhangi bir tuşa basınız.)).");
                    devammi = Console.ReadLine();
                    if (devammi=="E" || devammi=="e")
                    {
                        Console.Clear();
                        cikis = false;
                        
                    }
                    else
                    {
                        cikis = true;
                        Console.WriteLine("Başarıyla Çıkış Yapıldı");
                    }

                   
                }
            }




        }

    }
}
