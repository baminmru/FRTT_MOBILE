Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports LATIR
Imports System.Xml




' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://microsoft.com/webservices/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class FRTT_CE_Sync
    Inherits System.Web.Services.WebService




    <WebMethod()> _
    Public Function GetFTCount() As Integer
        Dim Manager As LATIR.Manager
        Manager = New LATIR.Manager

        Dim xml As XmlDocument
        xml = New XmlDocument
        Try
            xml.Load("d:\FRTT_PACK_Service\FRTTServiceConfig.xml")
        Catch ex As System.Exception

            Return -1 '"<error>Не найден файл конфигурации:" + "d:\FRTT_PACK_Service\FRTTServiceConfig.xml" + "</error>"
        End Try


        Dim node As XmlElement
        node = xml.LastChild()

        Dim MySite As String
        Dim User As String
        Dim Password As String


        MySite = node.Attributes.GetNamedItem("Site").Value
        User = node.Attributes.GetNamedItem("User").Value
        Password = (node.Attributes.GetNamedItem("Password").Value)

        Manager.Site = MySite
        Manager.XmlFile = "d:\FRTT_PACK_Service\latir_sites.xml"

        If Manager.Session Is Nothing Then
            Return -2 '"<error>Не найдено описание сайта:" + MySite + "</error>"
        End If
        If Not Manager.Session.Login(User, Password) Then
            Return -3 '"<error>Не удалось соединиться с базой данных." + "</error>"
        End If
        ' выгрузить из базы справочники типов фильтров
        Dim rs As DataTable
        rs = Manager.Session.GetData("select count(*) cnt from instance where objtype='FRDFT'")

        Manager.Session.Logout()
        Return rs.Rows(0)("cnt")
    End Function




    <WebMethod()> _
    Public Function Ping() As Boolean
        Dim Manager As LATIR.Manager
        Manager = New LATIR.Manager

        Dim xml As XmlDocument
        xml = New XmlDocument
        Try
            xml.Load("d:\FRTT_PACK_Service\FRTTServiceConfig.xml")
        Catch ex As System.Exception

            Return False
        End Try


        Dim node As XmlElement
        node = xml.LastChild()

        Dim MySite As String
        Dim User As String
        Dim Password As String


        MySite = node.Attributes.GetNamedItem("Site").Value
        User = node.Attributes.GetNamedItem("User").Value
        Password = (node.Attributes.GetNamedItem("Password").Value)

        Manager.Site = MySite
        Manager.XmlFile = "d:\FRTT_PACK_Service\latir_sites.xml"

        If Manager.Session Is Nothing Then
            Return False '"<error>Не найдено описание сайта:" + MySite + "</error>"
        End If
        If Not Manager.Session.Login(User, Password) Then
            Return False '"<error>Не удалось соединиться с базой данных." + "</error>"
        End If

        Manager.Session.Logout()
        Return True
    End Function


    <WebMethod()> _
    Public Function GetFT(ByVal FTIdx As Integer) As String
        Dim Manager As LATIR.Manager
        Manager = New LATIR.Manager

        Dim xml As XmlDocument
        xml = New XmlDocument
        Try
            xml.Load("d:\FRTT_PACK_Service\FRTTServiceConfig.xml")
        Catch
            Return "<error>Не найден файл конфигурации:" + "d:\FRTT_PACK_Service\FRTTServiceConfig.xml" + "</error>"
        End Try

        Dim node As XmlElement
        node = xml.LastChild()


        Dim MySite As String
        Dim User As String
        Dim Password As String


        MySite = node.Attributes.GetNamedItem("Site").Value
        User = node.Attributes.GetNamedItem("User").Value
        Password = (node.Attributes.GetNamedItem("Password").Value)

        Manager.Site = MySite
        Manager.XmlFile = "d:\FRTT_PACK_Service\latir_sites.xml"


        If Manager.Session Is Nothing Then
            Return "<error>Не найдено описание сайта:" + MySite + "</error>"
        End If

        If Not Manager.Session.Login(User, Password) Then
            Return "<error>Не удалось соединиться с базой данных." + "</error>"
        End If

        ' выгрузить из базы справочники типов фильтров
        Dim FT As FRDFT.FRDFT.Application
        Dim rs As DataTable
        rs = Manager.Session.GetData("select * from instance where objtype='FRDFT' order by instanceid")

        If FTIdx >= 0 And FTIdx < rs.Rows.Count Then

            FT = Nothing
            FT = Manager.GetInstanceObject(rs.Rows(FTIdx)("Instanceid"))
            If Not FT Is Nothing Then
                Dim x As New XmlDocument
                x.LoadXml("<" & FT.TypeName & "></" & FT.TypeName & ">")
                FT.XMLSave(x.LastChild, x)
                Manager.Session.Logout()
                Return x.OuterXml

            End If

        End If
        Manager.Session.Logout()
        Return ""
    End Function


    <WebMethod()> _
    Public Function GetLT() As String
        Dim Manager As LATIR.Manager
        Manager = New LATIR.Manager

        Dim xml As XmlDocument
        xml = New XmlDocument
        Try
            xml.Load("d:\FRTT_PACK_Service\FRTTServiceConfig.xml")
        Catch
            Return "<error>Не найден файл конфигурации:" + "d:\FRTT_PACK_Service\FRTTServiceConfig.xml" + "</error>"
        End Try



        Dim node As XmlElement
        node = xml.LastChild()

        Dim MySite As String
        Dim User As String
        Dim Password As String


        MySite = node.Attributes.GetNamedItem("Site").Value
        User = node.Attributes.GetNamedItem("User").Value
        Password = (node.Attributes.GetNamedItem("Password").Value)

        Manager.Site = MySite
        Manager.XmlFile = "d:\FRTT_PACK_Service\latir_sites.xml"

        If Manager.Session Is Nothing Then
            Return "<error>Не найдено описание сайта:" + MySite + "</error>"
        End If
        If Not Manager.Session.Login(User, Password) Then
            Return "<error>Не удалось соединиться с базой данных." + "</error>"
        End If

        ' выгрузить из базы справочники типов фильтров
        Dim LT As FRDLT.FRDLT.Application
        Dim rs As DataTable
        rs = Manager.Session.GetData("select * from instance where objtype='FRDLT' order by instanceid")

        If rs.Rows.Count > 0 Then
            LT = Nothing
            LT = Manager.GetInstanceObject(rs.Rows(0)("Instanceid"))
            If Not LT Is Nothing Then
                Dim x As New XmlDocument
                x.LoadXml("<" & LT.TypeName & "></" & LT.TypeName & ">")
                LT.XMLSave(x.LastChild, x)
                Manager.Session.Logout()
                Return x.OuterXml
            End If
        End If
        Manager.Session.Logout()
        Return ""
    End Function



    <WebMethod()> _
    Public Function SaveProtocol(ByVal P As String) As Boolean
        Dim Manager As LATIR.Manager
        Manager = New LATIR.Manager

        Dim xml As XmlDocument
        xml = New XmlDocument
        Try
            xml.Load("d:\FRTT_PACK_Service\FRTTServiceConfig.xml")
        Catch
            Return False '"<error>Не найден файл конфигурации:" + "d:\FRTT_PACK_Service\FRTTServiceConfig.xml" + "</error>"
        End Try



        Dim node As XmlElement
        node = xml.LastChild()

        Dim MySite As String
        Dim User As String
        Dim Password As String


        MySite = node.Attributes.GetNamedItem("Site").Value
        User = node.Attributes.GetNamedItem("User").Value
        Password = (node.Attributes.GetNamedItem("Password").Value)

        Manager.Site = MySite
        Manager.XmlFile = "d:\FRTT_PACK_Service\latir_sites.xml"

        If Manager.Session Is Nothing Then
            Return False '"<error>Не найдено описание сайта:" + MySite + "</error>"
        End If
        If Not Manager.Session.Login(User, Password) Then
            Return False '"<error>Не удалось соединиться с базой данных." + "</error>"
        End If

        Dim xdom As System.Xml.XmlDocument
        Dim drs As FRPACK.FRPACK.Application

        Dim typename As String, id As System.Guid, name As String

        Try
            xdom = New System.Xml.XmlDocument
            xdom.LoadXml(P)

            id = New Guid(xdom.LastChild.FirstChild.Attributes.GetNamedItem("ID").Value)

            typename = xdom.LastChild.FirstChild.Attributes.GetNamedItem("TYPENAME").Value
            name = xdom.LastChild.FirstChild.Attributes.GetNamedItem("NAME").Value

            drs = Manager.GetInstanceObject(id)
            If drs Is Nothing Then
                Manager.NewInstance(id, typename, name)
            End If
            drs = Manager.GetInstanceObject(id)
            If Not drs Is Nothing Then

                drs.LockResource(True)

                drs.AutoLoadPart = False

                drs.XMLLoad(xdom.LastChild, 0)

                drs.BatchUpdate()

                drs.UnLockResource()

            End If

            xdom = Nothing
        Catch ex As Exception
            Manager.Session.Logout()
            Return False
        End Try

        Manager.Session.Logout()
        Return True
    End Function



    <WebMethod()> _
    Public Function SaveLT(ByVal P As String) As Boolean
        Dim Manager As LATIR.Manager
        Manager = New LATIR.Manager

        Dim xml As XmlDocument
        xml = New XmlDocument
        Try
            xml.Load("d:\FRTT_PACK_Service\FRTTServiceConfig.xml")
        Catch
            Return False '"<error>Не найден файл конфигурации:" + "d:\FRTT_PACK_Service\FRTTServiceConfig.xml" + "</error>"
        End Try



        Dim node As XmlElement
        node = xml.LastChild()

        Dim MySite As String
        Dim User As String
        Dim Password As String


        MySite = node.Attributes.GetNamedItem("Site").Value
        User = node.Attributes.GetNamedItem("User").Value
        Password = (node.Attributes.GetNamedItem("Password").Value)

        Manager.Site = MySite
        Manager.XmlFile = "d:\FRTT_PACK_Service\latir_sites.xml"

        If Manager.Session Is Nothing Then
            Return False '"<error>Не найдено описание сайта:" + MySite + "</error>"
        End If
        If Not Manager.Session.Login(User, Password) Then
            Return False '"<error>Не удалось соединиться с базой данных." + "</error>"
        End If

        Dim xdom As System.Xml.XmlDocument
        Dim drs As FRDLT.FRDLT.Application

        Dim typename As String, id As System.Guid, name As String

        Try
            xdom = New System.Xml.XmlDocument
            xdom.LoadXml(P)

            id = New Guid(xdom.LastChild.FirstChild.Attributes.GetNamedItem("ID").Value)

            typename = xdom.LastChild.FirstChild.Attributes.GetNamedItem("TYPENAME").Value
            name = xdom.LastChild.FirstChild.Attributes.GetNamedItem("NAME").Value

            drs = Manager.GetInstanceObject(id)
            If drs Is Nothing Then
                Manager.NewInstance(id, typename, name)
            End If
            drs = Manager.GetInstanceObject(id)
            If Not drs Is Nothing Then

                drs.LockResource(True)

                drs.AutoLoadPart = False

                drs.XMLLoad(xdom.LastChild, 0)

                drs.BatchUpdate()

                drs.UnLockResource()

            End If

            xdom = Nothing
        Catch ex As Exception
            Manager.Session.Logout()
            Return False
        End Try

        Manager.Session.Logout()
        Return True
    End Function



    <WebMethod()> _
    Public Function SaveTAG(ByVal TagID As String, ByVal PackID As Integer) As Boolean
        Dim Manager As LATIR.Manager
        Manager = New LATIR.Manager

        Dim xml As XmlDocument
        xml = New XmlDocument
        Try
            xml.Load("d:\FRTT_PACK_Service\FRTTServiceConfig.xml")
        Catch
            Return False '"<error>Не найден файл конфигурации:" + "d:\FRTT_PACK_Service\FRTTServiceConfig.xml" + "</error>"
        End Try



        Dim node As XmlElement
        node = xml.LastChild()

        Dim MySite As String
        Dim User As String
        Dim Password As String


        MySite = node.Attributes.GetNamedItem("Site").Value
        User = node.Attributes.GetNamedItem("User").Value
        Password = (node.Attributes.GetNamedItem("Password").Value)

        Manager.Site = MySite
        Manager.XmlFile = "d:\FRTT_PACK_Service\latir_sites.xml"

        If Manager.Session Is Nothing Then
            Return False '"<error>Не найдено описание сайта:" + MySite + "</error>"
        End If
        If Not Manager.Session.Login(User, Password) Then
            Return False '"<error>Не удалось соединиться с базой данных." + "</error>"
        End If


        Dim fs As String
        Dim isLoad As Boolean
        Try
            Try
                fs = TagID.Substring(12, 10)
            Catch ex As Exception
                fs = "000000000000"
            End Try


            If Val("&H0" + fs) = 0 Then
                isLoad = False
            Else
                isLoad = True
            End If


            Dim ns As LATIR.NamedValues = New LATIR.NamedValues()
            ns.Add("Dev", "10.145.32." & PackID.ToString)
            ns.Add("Ant", 1, DbType.Int16)
            ns.Add("Tag", TagID)
            ns.Add("Dt", DateTime.Now, DbType.DateTime)

            ns.Add("Code", Val("&H0" + fs), DbType.Int64)

            Try
                Manager.Session().Exec("FRTT_SaveTag", ns)

            Catch ex As Exception

            End Try

            Try

                If isLoad Then
                    Dim dtsub As DataTable
                    Dim subID As Guid
                    Dim objSub As FRSUB.FRSUB.Application
                    Dim objSubData As FRSUB.FRSUB.FRSUB_DATA
                    dtsub = Manager.Session.GetData("select INSTANCEID from INSTANCE where objtype='FRSUB'")
                    If dtsub.Rows.Count = 0 Then
                        subID = Guid.NewGuid
                        objSub = Manager.NewInstance(subID, "FRSUB", "Компенсатор ошибок")
                    Else
                        subID = dtsub.Rows(0)("INSTANCEID")
                        objSub = Manager.GetInstanceObject(subID)
                    End If

                    objSub.FRSUB_DATA.Refresh()

                    dtsub = Manager.Session.GetData("select FRSUB_DATAID from FRSUB_DATA where substring(TagCode,1,12)=substring('" + TagID + "',1,12)")
                    If dtsub.Rows.Count = 0 Then
                        objSubData = objSub.FRSUB_DATA.Add
                    Else
                        subID = dtsub.Rows(0)("FRSUB_DATAID")
                        objSubData = objSub.FRSUB_DATA.Item(subID.ToString)
                    End If
                    With objSubData
                        .TAGCode = TagID
                        .PassDateTime = DateTime.Now
                        .PassUnloadPoint = FRSUB.FRSUB.enumBoolean.Boolean_Net
                        .ErrorRegTime = DateTime.Now
                        .Save()
                    End With
                    Manager.Session.Logout()
                    Return True
                Else
                    Try
                        Manager.Session.GetData("update FRSUB_DATA set PassUnloadPoint = -1,PassDateTime=" + Manager.Session.GetProvider.MakeMSSQLDate(DateTime.Now) + " where substring(FRSUB_DATA.TAGCode ,1,12)=substring('" + TagID + "',1,12)")
                        Manager.Session.Logout()
                        Return True
                    Catch ex As Exception
                        Manager.Session.Logout()
                        Return False
                    End Try
                End If

            Catch ex As Exception
                Manager.Session.Logout()
                Return False
            End Try
        Catch ex As Exception
            Manager.Session.Logout()
            Return False
        End Try

        Manager.Session.Logout()
        Return True
    End Function


    <WebMethod()> _
    Public Function EncodeTag(ByVal TagID As String) As String
        Dim Manager As LATIR.Manager
        Manager = New LATIR.Manager

        Dim xml As XmlDocument
        xml = New XmlDocument
        Try
            xml.Load("d:\FRTT_PACK_Service\FRTTServiceConfig.xml")
        Catch
            Return "<error>Не найден файл конфигурации:" + "d:\FRTT_PACK_Service\FRTTServiceConfig.xml" + "</error>"
        End Try

        Dim node As XmlElement
        node = xml.LastChild()

        Dim MySite As String
        Dim User As String
        Dim Password As String
        Dim NewTagID As String = TagID


        MySite = node.Attributes.GetNamedItem("Site").Value
        User = node.Attributes.GetNamedItem("User").Value
        Password = (node.Attributes.GetNamedItem("Password").Value)

        Manager.Site = MySite
        Manager.XmlFile = "d:\FRTT_PACK_Service\latir_sites.xml"

        If Manager.Session Is Nothing Then
            Return "<error>Не найдено описание сайта:" + MySite + "</error>"
        End If
        If Not Manager.Session.Login(User, Password) Then
            Return "<error>Не удалось соединиться с базой данных." + "</error>"
        End If



        Try
            Dim dt As DataTable
            dt = Manager.Session.GetData("select TagCode,Passunloadpoint from FRSUB_DATA where substring(TAGcode,1,12)='" + TagID.Substring(0, 12) + "'")
            If dt.Rows.Count > 0 Then
                If dt.Rows(0)("PassUnloadPoint") = 0 Then
                    NewTagID = dt.Rows(0)("TagCode")
                Else
                    NewTagID = TagID.Substring(0, 12) + "0000000000AB"
                End If
            End If


        Catch ex As Exception
            Manager.Session.Logout()
            Return NewTagID
        End Try

        Manager.Session.Logout()
        Return NewTagID
    End Function

    '    select frdft_info.TheCode ,frdft_info.thenum,TheAnt,IsLoadPoint,frdM_INFO.TheCode MachineType, FRWM_INFO.TheCode Machine
    ' from  FRWM_POINTS join FRRC_INFO on FRWM_POINTS.TheRF = FRRC_INFOID join FRWM_INFO on FRRC_INFO.TheWM=FRWM_INFOID join frdM_INFO on FRWM_INFO.WMType =frdM_INFOID join frdft_info on FRWM_POINTS.TheFT =frdft_info.frdft_infoid where FRWM_POINTS.isOFf=0

    <WebMethod()> _
    Public Function GetWMFTCount(ByVal wmType As String, wmGroup As String) As Integer
        Dim Manager As LATIR.Manager
        Manager = New LATIR.Manager

        Dim xml As XmlDocument
        xml = New XmlDocument
        Try
            xml.Load("d:\FRTT_PACK_Service\FRTTServiceConfig.xml")
        Catch ex As System.Exception

            Return -1 '"<error>Не найден файл конфигурации:" + "d:\FRTT_PACK_Service\FRTTServiceConfig.xml" + "</error>"
        End Try


        Dim node As XmlElement
        node = xml.LastChild()

        Dim MySite As String
        Dim User As String
        Dim Password As String


        MySite = node.Attributes.GetNamedItem("Site").Value
        User = node.Attributes.GetNamedItem("User").Value
        Password = (node.Attributes.GetNamedItem("Password").Value)

        Manager.Site = MySite
        Manager.XmlFile = "d:\FRTT_PACK_Service\latir_sites.xml"

        If Manager.Session Is Nothing Then
            Return -2 '"<error>Не найдено описание сайта:" + MySite + "</error>"
        End If
        If Not Manager.Session.Login(User, Password) Then
            Return -3 '"<error>Не удалось соединиться с базой данных." + "</error>"
        End If
        ' выгрузить из базы справочники типов фильтров
        Dim rs As DataTable
        rs = Manager.Session.GetData("select count(*) cnt  from  FRWM_POINTS join FRRC_INFO on FRWM_POINTS.TheRF = FRRC_INFOID join FRWM_INFO on FRRC_INFO.TheWM=FRWM_INFOID join frdM_INFO on FRWM_INFO.WMType =frdM_INFOID join frdft_info on FRWM_POINTS.TheFT =frdft_info.frdft_infoid where FRWM_POINTS.isOFf=0 " + _
                                     " and frdM_INFO.TheCode in (" + wmType + ") and  FRWM_INFO.TheCode like'%" + wmGroup + "'")
        Manager.Session.Logout()
        Return rs.Rows(0)("cnt")
    End Function


    <WebMethod()> _
    Public Function GetWMFT(ByVal wmType As String, wmGroup As String, ByVal FTIdx As Integer) As String
        Dim Manager As LATIR.Manager
        Manager = New LATIR.Manager

        Dim xml As XmlDocument
        xml = New XmlDocument
        Try
            xml.Load("d:\FRTT_PACK_Service\FRTTServiceConfig.xml")
        Catch
            Return "<error>Не найден файл конфигурации:" + "d:\FRTT_PACK_Service\FRTTServiceConfig.xml" + "</error>"
        End Try

        Dim node As XmlElement
        node = xml.LastChild()


        Dim MySite As String
        Dim User As String
        Dim Password As String


        MySite = node.Attributes.GetNamedItem("Site").Value
        User = node.Attributes.GetNamedItem("User").Value
        Password = (node.Attributes.GetNamedItem("Password").Value)

        Manager.Site = MySite
        Manager.XmlFile = "d:\FRTT_PACK_Service\latir_sites.xml"


        If Manager.Session Is Nothing Then
            Return "<error>Не найдено описание сайта:" + MySite + "</error>"
        End If

        If Not Manager.Session.Login(User, Password) Then
            Return "<error>Не удалось соединиться с базой данных." + "</error>"
        End If

        ' выгрузить из базы справочники типов фильтров
        Dim FT As FRDFT.FRDFT.Application
        Dim rs As DataTable
        rs = Manager.Session.GetData("select frdft_info.TheCode  from  FRWM_POINTS join FRRC_INFO on FRWM_POINTS.TheRF = FRRC_INFOID join FRWM_INFO on FRRC_INFO.TheWM=FRWM_INFOID join frdM_INFO on FRWM_INFO.WMType =frdM_INFOID join frdft_info on FRWM_POINTS.TheFT =frdft_info.frdft_infoid where FRWM_POINTS.isOFf=0 " + _
                                     " and frdM_INFO.TheCode in (" + wmType + ") and  FRWM_INFO.TheCode like'%" + wmGroup + "' order by frdft_info.TheCode")

        If FTIdx >= 0 And FTIdx < rs.Rows.Count Then
            Manager.Session.Logout()
                Return rs.Rows(FTIdx)("TheCode")

        End If
        Manager.Session.Logout()
        Return ""
    End Function

End Class