using System;
using NXOpen;
using NXOpen.UF;

public class Program
{
    private const string V = "model2";

    // class members
    private static Session theSession;
    private static UI theUI;
    private static UFSession theUfSession;
    public static Program theProgram;
    public static bool isDisposeCalled;

    //------------------------------------------------------------------------------
    // Constructor
    //------------------------------------------------------------------------------
    public Program()
    {
        try
        {
            theSession = Session.GetSession();
            theUI = UI.GetUI();
            theUfSession = UFSession.GetUFSession();
            isDisposeCalled = false;
        }
        catch (NXOpen.NXException ex)
        {
            // ---- Enter your exception handling code here -----
            // UI.GetUI().NXMessageBox.Show("Message", NXMessageBox.DialogType.Error, ex.Message);
        }
    }

    public static void subtraction()

    {//Переменная задающая значения направления выдавливания ось CX
        double[] direction6 = { 1.00, 0.00, 0.00 };
        //Задание координат начальной точки вращения
        double[] ref_pt6 = new double[3];
        ref_pt6[0] = 0.00;
        ref_pt6[1] = 0.00;
        ref_pt6[2] = 0.00;
        //Задание пределов вращения
        string[] limit6 = { "0", "360"};
    //объявление массива объектов вращения
    Tag[] objarray6 = new Tag[5];
    //Объявление и определение переменны содержащих координаты точек отрезков эскиза
double[] l1_endpt1 = { 5, 0, 0.00 };
    double[] l1_endpt2 = { 200, 0, 0.00 };
    double[] l2_endpt1 = { 200, 0, 0.00 };
    double[] l2_endpt2 = { 200, 22.85, 0.00 };
    double[] l3_endpt1 = { 200, 22.85, 0.00 };
    double[] l3_endpt2 = { 20, 22.85, 0.00 };
    double[] l4_endpt1 = { 20, 22.85, 0.00 };
    double[] l4_endpt2 = { 5, 0, 0.00 };
    // Переменная для записи указателя на объект, получившийся в результате операции вырезания вращением
Tag[] features6;
    //Создание структур NX соответствующих отрезкам эскиза
    UFCurve.Line line1 = new UFCurve.Line();
    UFCurve.Line line2 = new UFCurve.Line();
    UFCurve.Line line3 = new UFCurve.Line();
    UFCurve.Line line4 = new UFCurve.Line();
    //-----------Задаются конечные точки отрезков----------------
    line1.start_point = new double[3];
line1.start_point[0] = l1_endpt1[0];
line1.start_point[1] = l1_endpt1[1];
line1.start_point[2] = l1_endpt1[2];
line1.end_point = new double[3];
line1.end_point[0] = l1_endpt2[0];
line1.end_point[1] = l1_endpt2[1];
line1.end_point[2] = l1_endpt2[2];
line2.start_point = new double[3];
line2.start_point[0] = l2_endpt1[0];
line2.start_point[1] = l2_endpt1[1];
line2.start_point[2] = l2_endpt1[2];
line2.end_point = new double[3];
line2.end_point[0] = l2_endpt2[0];
line2.end_point[1] = l2_endpt2[1];
line2.end_point[2] = l2_endpt2[2];
line3.start_point = new double[3];
line3.start_point[0] = l3_endpt1[0];
line3.start_point[1] = l3_endpt1[1];
line3.start_point[2] = l3_endpt1[2];
line3.end_point = new double[3];
line3.end_point[0] = l3_endpt2[0];
line3.end_point[1] = l3_endpt2[1];
line3.end_point[2] = l3_endpt2[2];
line4.start_point = new double[3];
line4.start_point[0] = l4_endpt1[0];
line4.start_point[1] = l4_endpt1[1];
line4.start_point[2] = l4_endpt1[2];
line4.end_point = new double[3];
line4.end_point[0] = l4_endpt2[0];
line4.end_point[1] = l4_endpt2[1];
line4.end_point[2] = l4_endpt2[2];
//---------------------------------------------------
//Построение отрезков в 3D пространстве
theUfSession.Curve.CreateLine(ref line1, out objarray6[0]);
theUfSession.Curve.CreateLine(ref line2, out objarray6[1]);
theUfSession.Curve.CreateLine(ref line3, out objarray6[2]);
theUfSession.Curve.CreateLine(ref line4, out objarray6[3]);
//Создание операции вырезания вращением
theUfSession.Modl.CreateRevolved(objarray6, limit6, ref_pt6,
direction6, FeatureSigns.Negative, out features6);
}


    public static void extrusion()
    {
        double[] direction4 = { 0.0, 0.0, 1.0 };
        //Переменная задающая значения направления выдавливания ось CZ
        double[] ref_pt4 = new double[3];
        //Требуемая, но не используемая переменная
        string taper_angle4 = "0.0";
        //Переменная, определяющая значение уклона при выдавливании
        string[] limit4 = { "-10 ", "3" };
        //Переменная, определяющая параметры начала и конца операции выдавливания
        int i4, count4 = 6;
        // Переменная счетчик и число объектов в эскизе
        Tag[] objarray4 = new Tag[7];
        // Массив объектов из 7 элементов. Заполняется указателями на элементы эскиза выдавливания при их построении(линии и дуги)
        Tag wcs_tag1, matrix_tag1, wcs_tag2, matrix_tag2, wcs_tag3, matrix_tag3, wcs_tag4, matrix_tag4;
        //Переменные wcs_tag1 – для записи указателя на текущую систему координат; matrix_tag1 – для записи идентификатора матрицы связанного с объектом и т.д.
        Tag[] features4;
        //features4 – переменная для записи указателя на объект, получившийся в результате операции выдавливания
        double[] arc1_centerpt1 = { 35, -50, 30.5 };
        //Переменная содержащая значения координат центра дуги 1{x,y,z}
        double arc1_start_ang1 = 0;
        //Переменная содержащая значение угла начала дуги 1 (в радианах)
        double arc1_end_ang1 = 3.14159265358979324 * 2;
        //Переменная содержащая значение угла конца дуги 1 (в радианах)
        double arc1_rad1 = 5;
        //Переменная содержащая значение радиуса дуги 1 (в радианах)
        UFCurve.Arc arc1 = new UFCurve.Arc();



        //Создание структуры NX соответствующей дуге 1
        //Установка параметров дуги 1
        arc1.start_angle = arc1_start_ang1;
        //Начальный угол
        arc1.end_angle = arc1_end_ang1;
        //Конечный угол
        arc1.arc_center = new double[3];
        //Центр дуги 1
        arc1.arc_center[0] = arc1_centerpt1[0];
        //Координата центра дуги 1 по X
        arc1.arc_center[1] = arc1_centerpt1[1];
        //Координата центра дуги 1 по Y
        arc1.arc_center[2] = arc1_centerpt1[2];
        //Координата центра дуги 1 по Z
        arc1.radius = arc1_rad1;
        //Радиус дуги 1
        theUfSession.Csys.AskWcs(out wcs_tag1);
        //Получения указателя на активную систему координат
        theUfSession.Csys.AskMatrixOfObject(wcs_tag1, out
    matrix_tag1);
        //Получение идентификатора матрицы, связанного с объектом, указатель на который содержится в wcs_tag1
        arc1.matrix_tag = matrix_tag1;
        //Определение указателя матрицы дуги 1
        /*----------------------------------------------------------*/
        /***********************Аналогично дуге 1********************/
        double[] arc2_centerpt2 = { 35, 50, 30.5 };
        double arc2_start_ang2 = 0;
        double arc2_end_ang2 = 3.14159265358979324 * 2;
        double arc2_rad2 = 5;
        UFCurve.Arc arc2 = new UFCurve.Arc();
        arc2.start_angle = arc2_start_ang2;
        arc2.end_angle = arc2_end_ang2;
        arc2.arc_center = new double[3];
        arc2.arc_center[0] = arc2_centerpt2[0];
        arc2.arc_center[1] = arc2_centerpt2[1];
        arc2.arc_center[2] = arc2_centerpt2[2];
        arc2.radius = arc2_rad2;
        theUfSession.Csys.AskWcs(out wcs_tag2);
        theUfSession.Csys.AskMatrixOfObject(wcs_tag2, out matrix_tag2);
        arc2.matrix_tag = matrix_tag2;
        /*----------------------------------------------------------*/
        /***********************Аналогично дуге 1********************/
        double[] arc3_centerpt3 = { 35, -50, 30.5 };
        double arc3_start_ang3 = -3.14159265358979324;
        double arc3_end_ang3 = 0;
        double arc3_rad3 = 15;
        UFCurve.Arc arc3 = new UFCurve.Arc();
        arc3.start_angle = arc3_start_ang3;
        arc3.end_angle = arc3_end_ang3;
        arc3.arc_center = new double[3];
        arc3.arc_center[0] = arc3_centerpt3[0];
        arc3.arc_center[1] = arc3_centerpt3[1];
        arc3.arc_center[2] = arc3_centerpt3[2];
        arc3.radius = arc3_rad3;
        theUfSession.Csys.AskWcs(out wcs_tag3);
        theUfSession.Csys.AskMatrixOfObject(wcs_tag3, out matrix_tag3);
        arc3.matrix_tag = matrix_tag3;
        /*----------------------------------------------------------*/
        /***********************Аналогично дуге 1********************/
        double[] arc4_centerpt4 = { 35, 50, 30.5 };
        double arc4_start_ang4 = 0;
        double arc4_end_ang4 = 3.14159265358979324;
        double arc4_rad4 = 15;
        UFCurve.Arc arc4 = new UFCurve.Arc();
        arc4.start_angle = arc4_start_ang4;
        arc4.end_angle = arc4_end_ang4;
        arc4.arc_center = new double[3];
        arc4.arc_center[0] = arc4_centerpt4[0];
        arc4.arc_center[1] = arc4_centerpt4[1];
        arc4.arc_center[2] = arc4_centerpt4[2];
        arc4.radius = arc4_rad4;
        theUfSession.Csys.AskWcs(out wcs_tag4);
        theUfSession.Csys.AskMatrixOfObject(wcs_tag4, out matrix_tag4);
        arc4.matrix_tag = matrix_tag4;
        /*----------------------------------------------------------*/
        //Определение переменных содержащих координаты начальной и конечной точек отрезков 1 и 2
        double[] l1_endpt1 = { 20, -50, 30.5 };
        //Координаты начальной точки отрезка 1
        double[] l1_endpt2 = { 20, 50, 30.5 };
        //Координаты конечной точки отрезка 1
        double[] l2_endpt1 = { 50, 50, 30.5 };
        //Координаты начальной точки отрезка 2
        double[] l2_endpt2 = { 50, -50, 30.5 };
        //Координаты конечной точки отрезка 2
        UFCurve.Line line1 = new UFCurve.Line();
        //Создание переменной объекта отрезок 1
        UFCurve.Line line2 = new UFCurve.Line();
        //Создание переменной объекта отрезок 2
        //Задание параметров отрезков
        line1.start_point = new double[3];
        line1.start_point[0] = l1_endpt1[0];
        //Координата Х начальной точки отрезка 1
        line1.start_point[1] = l1_endpt1[1];
        //Координата Y начальной точки отрезка 1
        line1.start_point[2] = l1_endpt1[2];
        //Координата Z начальной точки отрезка 1
        line1.end_point = new double[3];
        line1.end_point[0] = l1_endpt2[0];
        //Координата Х конечной точки отрезка 1
        line1.end_point[1] = l1_endpt2[1];
        //Координата Y конечной точки отрезка 1
        line1.end_point[2] = l1_endpt2[2];
        //Координата Z конечной точки отрезка 1
        line2.start_point = new double[3];
        line2.start_point[0] = l2_endpt1[0];
        //Координата Х начальной точки отрезка 2
        line2.start_point[1] = l2_endpt1[1];
        //Координата Y начальной точки отрезка 2
        line2.start_point[2] = l2_endpt1[2];
        //Координата Z начальной точки отрезка 2
        line2.end_point = new double[3];
        line2.end_point[0] = l2_endpt2[0];
        //Координата Х конечной точки отрезка 2
        line2.end_point[1] = l2_endpt2[1];
        //Координата Y конечной точки отрезка 2
        line2.end_point[2] = l2_endpt2[2];
        //Координата Z конечной точки отрезка 2
        theUfSession.Curve.CreateArc(ref arc1/*объект дуга 1*/, out
    objarray4[0]/*указатель на созданный объект дуга 1 – 0-й элемент
массива объектов выдавливания*/);
        //Построение дуги 1
        theUfSession.Curve.CreateLine(ref line1, out objarray4[1]);
        //Построение отрезка 1
        theUfSession.Curve.CreateLine(ref line2, out objarray4[2]);
        //Построение отрезка 2
        theUfSession.Curve.CreateArc(ref arc2, out objarray4[3]);
        //Построение дуги 2
        theUfSession.Curve.CreateArc(ref arc3, out objarray4[4]);
        //Построение дуги 3
        theUfSession.Curve.CreateArc(ref arc4, out objarray4[5]);
        //Построение дуги 4
        //Создание операции выдавливания
        theUfSession.Modl.CreateExtruded(
    objarray4/*Массив объектов выдавливания*/,
    taper_angle4/*Угол уклона*/,
    limit4/*Начало и конец выдавливания*/,
    ref_pt4 /*Пустой параметр*/,
    direction4/*Направление выдавливания*/,
    FeatureSigns.Positive/*Буревая операция (ОБЕДИНЕНИЕ)*/,
    out features4/*Выходной параметр - указатель на результат
операции*/);
    }


    public static void extrusion1()
    {
        double[] direction4 = { 0.0, 0.0, 1.0 };
        //Переменная задающая значения направления выдавливания ось CZ
        double[] ref_pt4 = new double[3];
        //Требуемая, но не используемая переменная
        string taper_angle4 = "0.0";
        //Переменная, определяющая значение уклона при выдавливании
        string[] limit4 = { "-10 ", "3" };
        //Переменная, определяющая параметры начала и конца операции выдавливания
        int i4, count4 = 6;
        // Переменная счетчик и число объектов в эскизе
        Tag[] objarray4 = new Tag[7];
        // Массив объектов из 7 элементов. Заполняется указателями на элементы эскиза выдавливания при их построении(линии и дуги)
        Tag wcs_tag1, matrix_tag1, wcs_tag2, matrix_tag2, wcs_tag3, matrix_tag3, wcs_tag4, matrix_tag4;
        //Переменные wcs_tag1 – для записи указателя на текущую систему координат; matrix_tag1 – для записи идентификатора матрицы связанного с объектом и т.д.
        Tag[] features4;
        //features4 – переменная для записи указателя на объект, получившийся в результате операции выдавливания
        double[] arc1_centerpt1 = { 135, -50, 30.5 };
        //Переменная содержащая значения координат центра дуги 1{x,y,z}
        double arc1_start_ang1 = 0;
        //Переменная содержащая значение угла начала дуги 1 (в радианах)
        double arc1_end_ang1 = 3.14159265358979324 * 2;
        //Переменная содержащая значение угла конца дуги 1 (в радианах)
        double arc1_rad1 = 5;
        //Переменная содержащая значение радиуса дуги 1 (в радианах)
        UFCurve.Arc arc1 = new UFCurve.Arc();



        //Создание структуры NX соответствующей дуге 1
        //Установка параметров дуги 1
        arc1.start_angle = arc1_start_ang1;
        //Начальный угол
        arc1.end_angle = arc1_end_ang1;
        //Конечный угол
        arc1.arc_center = new double[3];
        //Центр дуги 1
        arc1.arc_center[0] = arc1_centerpt1[0];
        //Координата центра дуги 1 по X
        arc1.arc_center[1] = arc1_centerpt1[1];
        //Координата центра дуги 1 по Y
        arc1.arc_center[2] = arc1_centerpt1[2];
        //Координата центра дуги 1 по Z
        arc1.radius = arc1_rad1;
        //Радиус дуги 1
        theUfSession.Csys.AskWcs(out wcs_tag1);
        //Получения указателя на активную систему координат
        theUfSession.Csys.AskMatrixOfObject(wcs_tag1, out
    matrix_tag1);
        //Получение идентификатора матрицы, связанного с объектом, указатель на который содержится в wcs_tag1
        arc1.matrix_tag = matrix_tag1;
        //Определение указателя матрицы дуги 1
        /*----------------------------------------------------------*/
        /***********************Аналогично дуге 1********************/
        double[] arc2_centerpt2 = { 135, 50, 30.5 };
        double arc2_start_ang2 = 0;
        double arc2_end_ang2 = 3.14159265358979324 * 2;
        double arc2_rad2 = 5;
        UFCurve.Arc arc2 = new UFCurve.Arc();
        arc2.start_angle = arc2_start_ang2;
        arc2.end_angle = arc2_end_ang2;
        arc2.arc_center = new double[3];
        arc2.arc_center[0] = arc2_centerpt2[0];
        arc2.arc_center[1] = arc2_centerpt2[1];
        arc2.arc_center[2] = arc2_centerpt2[2];
        arc2.radius = arc2_rad2;
        theUfSession.Csys.AskWcs(out wcs_tag2);
        theUfSession.Csys.AskMatrixOfObject(wcs_tag2, out matrix_tag2);
        arc2.matrix_tag = matrix_tag2;
        /*----------------------------------------------------------*/
        /***********************Аналогично дуге 1********************/
        double[] arc3_centerpt3 = { 135, -50, 30.5 };
        double arc3_start_ang3 = -3.14159265358979324;
        double arc3_end_ang3 = 0;
        double arc3_rad3 = 15;
        UFCurve.Arc arc3 = new UFCurve.Arc();
        arc3.start_angle = arc3_start_ang3;
        arc3.end_angle = arc3_end_ang3;
        arc3.arc_center = new double[3];
        arc3.arc_center[0] = arc3_centerpt3[0];
        arc3.arc_center[1] = arc3_centerpt3[1];
        arc3.arc_center[2] = arc3_centerpt3[2];
        arc3.radius = arc3_rad3;
        theUfSession.Csys.AskWcs(out wcs_tag3);
        theUfSession.Csys.AskMatrixOfObject(wcs_tag3, out matrix_tag3);
        arc3.matrix_tag = matrix_tag3;
        /*----------------------------------------------------------*/
        /***********************Аналогично дуге 1********************/
        double[] arc4_centerpt4 = { 135, 50, 30.5 };
        double arc4_start_ang4 = 0;
        double arc4_end_ang4 = 3.14159265358979324;
        double arc4_rad4 = 15;
        UFCurve.Arc arc4 = new UFCurve.Arc();
        arc4.start_angle = arc4_start_ang4;
        arc4.end_angle = arc4_end_ang4;
        arc4.arc_center = new double[3];
        arc4.arc_center[0] = arc4_centerpt4[0];
        arc4.arc_center[1] = arc4_centerpt4[1];
        arc4.arc_center[2] = arc4_centerpt4[2];
        arc4.radius = arc4_rad4;
        theUfSession.Csys.AskWcs(out wcs_tag4);
        theUfSession.Csys.AskMatrixOfObject(wcs_tag4, out matrix_tag4);
        arc4.matrix_tag = matrix_tag4;
        /*----------------------------------------------------------*/
        //Определение переменных содержащих координаты начальной и конечной точек отрезков 1 и 2
        double[] l1_endpt1 = { 120, -50, 30.5 };
        //Координаты начальной точки отрезка 1
        double[] l1_endpt2 = { 120, 50, 30.5 };
        //Координаты конечной точки отрезка 1
        double[] l2_endpt1 = { 150, 50, 30.5 };
        //Координаты начальной точки отрезка 2
        double[] l2_endpt2 = { 150, -50, 30.5 };
        //Координаты конечной точки отрезка 2
        UFCurve.Line line1 = new UFCurve.Line();
        //Создание переменной объекта отрезок 1
        UFCurve.Line line2 = new UFCurve.Line();
        //Создание переменной объекта отрезок 2
        //Задание параметров отрезков
        line1.start_point = new double[3];
        line1.start_point[0] = l1_endpt1[0];
        //Координата Х начальной точки отрезка 1
        line1.start_point[1] = l1_endpt1[1];
        //Координата Y начальной точки отрезка 1
        line1.start_point[2] = l1_endpt1[2];
        //Координата Z начальной точки отрезка 1
        line1.end_point = new double[3];
        line1.end_point[0] = l1_endpt2[0];
        //Координата Х конечной точки отрезка 1
        line1.end_point[1] = l1_endpt2[1];
        //Координата Y конечной точки отрезка 1
        line1.end_point[2] = l1_endpt2[2];
        //Координата Z конечной точки отрезка 1
        line2.start_point = new double[3];
        line2.start_point[0] = l2_endpt1[0];
        //Координата Х начальной точки отрезка 2
        line2.start_point[1] = l2_endpt1[1];
        //Координата Y начальной точки отрезка 2
        line2.start_point[2] = l2_endpt1[2];
        //Координата Z начальной точки отрезка 2
        line2.end_point = new double[3];
        line2.end_point[0] = l2_endpt2[0];
        //Координата Х конечной точки отрезка 2
        line2.end_point[1] = l2_endpt2[1];
        //Координата Y конечной точки отрезка 2
        line2.end_point[2] = l2_endpt2[2];
        //Координата Z конечной точки отрезка 2
        theUfSession.Curve.CreateArc(ref arc1/*объект дуга 1*/, out
    objarray4[0]/*указатель на созданный объект дуга 1 – 0-й элемент
массива объектов выдавливания*/);
        //Построение дуги 1
        theUfSession.Curve.CreateLine(ref line1, out objarray4[1]);
        //Построение отрезка 1
        theUfSession.Curve.CreateLine(ref line2, out objarray4[2]);
        //Построение отрезка 2
        theUfSession.Curve.CreateArc(ref arc2, out objarray4[3]);
        //Построение дуги 2
        theUfSession.Curve.CreateArc(ref arc3, out objarray4[4]);
        //Построение дуги 3
        theUfSession.Curve.CreateArc(ref arc4, out objarray4[5]);
        //Построение дуги 4
        //Создание операции выдавливания
        theUfSession.Modl.CreateExtruded(
    objarray4/*Массив объектов выдавливания*/,
    taper_angle4/*Угол уклона*/,
    limit4/*Начало и конец выдавливания*/,
    ref_pt4 /*Пустой параметр*/,
    direction4/*Направление выдавливания*/,
    FeatureSigns.Positive/*Буревая операция (ОБЕДИНЕНИЕ)*/,
    out features4/*Выходной параметр - указатель на результат
операции*/);
    }


    //------------------------------------------------------------------------------
    //  Explicit Activation
    //      This entry point is used to activate the application explicitly
    //------------------------------------------------------------------------------
    public static int Main(string[] args)
    {
        int retValue = 0;
        try
        {
            theProgram = new Program();

            //TODO: Add your application code here 
            Tag UFPart1;
            string name1 = V;
            int units1 = 1;
            theUfSession.Part.New(name1, units1, out UFPart1);

            double[] l1_endpt1 = { 0, 2.5, 0.00 };
            double[] l1_endpt2 = { 0, 30.5, 0.00 };
            double[] l2_endpt1 = { 0, 30.5, 0.00 };
            double[] l2_endpt2 = { 200, 30.5, 0.00 };
            double[] l3_endpt1 = { 200, 30.5, 0.00 };
            double[] l3_endpt2 = { 200, 2.5, 0.00 };
            double[] l4_endpt1 = { 200, 2.5, 0.00 };
            double[] l4_endpt2 = { 0, 2.5, 0.00 };


            UFCurve.Line line1 = new UFCurve.Line();
            UFCurve.Line line2 = new UFCurve.Line();
            UFCurve.Line line3 = new UFCurve.Line();
            UFCurve.Line line4 = new UFCurve.Line();


            line1.start_point = new double[3];
            line1.start_point[0] = l1_endpt1[0];
            line1.start_point[1] = l1_endpt1[1];
            line1.start_point[2] = l1_endpt1[2];
            line1.end_point = new double[3];
            line1.end_point[0] = l1_endpt2[0];
            line1.end_point[1] = l1_endpt2[1];
            line1.end_point[2] = l1_endpt2[2];
            line2.start_point = new double[3];
            line2.start_point[0] = l2_endpt1[0];
            line2.start_point[1] = l2_endpt1[1];
            line2.start_point[2] = l2_endpt1[2];
            line2.end_point = new double[3];
            line2.end_point[0] = l2_endpt2[0];
            line2.end_point[1] = l2_endpt2[1];
            line2.end_point[2] = l2_endpt2[2];
            line3.start_point = new double[3];
            line3.start_point[0] = l3_endpt1[0];
            line3.start_point[1] = l3_endpt1[1];
            line3.start_point[2] = l3_endpt1[2];
            line3.end_point = new double[3];
            line3.end_point[0] = l3_endpt2[0];
            line3.end_point[1] = l3_endpt2[1];
            line3.end_point[2] = l3_endpt2[2];
            line4.start_point = new double[3];
            line4.start_point[0] = l4_endpt1[0];
            line4.start_point[1] = l4_endpt1[1];
            line4.start_point[2] = l4_endpt1[2];
            line4.end_point = new double[3];
            line4.end_point[0] = l4_endpt2[0];
            line4.end_point[1] = l4_endpt2[1];
            line4.end_point[2] = l4_endpt2[2];


            Tag[] objarray1 = new Tag[7];
            theUfSession.Curve.CreateLine(ref line1, out
            objarray1[0]);
            theUfSession.Curve.CreateLine(ref line2, out
            objarray1[1]);
            theUfSession.Curve.CreateLine(ref line3, out
            objarray1[2]);
            theUfSession.Curve.CreateLine(ref line4, out
            objarray1[3]);


            double[] ref_pt1 = new double[3];
            ref_pt1[0] = 0.00;
            ref_pt1[1] = 0.00;
            ref_pt1[2] = 0.00;

            double[] direction1 = { 1.00, 0.00, 0.00 };
            string[] limit1 = { "0", "360" };
            Tag[] features1;

            theUfSession.Modl.CreateRevolved(objarray1, limit1, ref_pt1, direction1, FeatureSigns.Nullsign, out features1);

            extrusion();
            extrusion1();
            subtraction();

            theUfSession.Part.Save();


            theProgram.Dispose();
        }
        catch (NXOpen.NXException ex)
        {
            // ---- Enter your exception handling code here -----
            UI.GetUI().NXMessageBox.Show("Message", NXMessageBox.DialogType.Information, "Smth's going wrong");
        }
        return retValue;
    }

    //------------------------------------------------------------------------------
    // Following method disposes all the class members
    //------------------------------------------------------------------------------
    public void Dispose()
    {
        try
        {
            if (isDisposeCalled == false)
            {
                //TODO: Add your application code here 
            }
            isDisposeCalled = true;
        }
        catch (NXOpen.NXException ex)
        {
            // ---- Enter your exception handling code here -----

        }
    }

    public static int GetUnloadOption(string arg)
    {
        //Unloads the image explicitly, via an unload dialog
        //return System.Convert.ToInt32(Session.LibraryUnloadOption.Explicitly);

        //Unloads the image immediately after execution within NX
        // return System.Convert.ToInt32(Session.LibraryUnloadOption.Immediately);

        //Unloads the image when the NX session terminates
        return System.Convert.ToInt32(Session.LibraryUnloadOption.AtTermination);
    }

}

